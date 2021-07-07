using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class AdvancedSettings : DarkModeForm
    {
        Dictionary<string, string> propertyDescriptions;

        public AdvancedSettings()
        {
            InitializeComponent();

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += AdvancedSettings_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };

            listView1.BeginUpdate();
            foreach (var s in SettingsManager.GetAll())
            {
                var i = new ListViewItem(s.Key);
                i.SubItems.Add(s.Value.Item1.Name);
                i.SubItems.Add(s.Value.Item2.ToString());
                listView1.Items.Add(i);
            }
            listView1.EndUpdate();
            listView1.ItemActivate += ListView1_ItemActivate;

            propertyDescriptions = new Dictionary<string, string>();
            var lines = resources.settingsDescriptions.Split('\n');
            foreach (var ln in lines)
            {
                if (ln.Trim().Length < 1)
                    continue;

                var parts = Regex.Split(ln, "\t+");    // vv just in case vv
                propertyDescriptions[parts[0]] = parts[1].Replace("\r", "");
            }
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            var key = listView1.SelectedItems[0].Text;
            var (type, value) = SettingsManager.GetRaw(key);

            if (type == typeof(bool))
                value = !(bool)value;
            else if (type == typeof(int))
                value = AskInt((int)value);
            else if (type == typeof(string))
                value = AskString((string)value);
            else if (type == typeof(Color))
                value = AskColor((Color)value);
            else if (type == typeof(Font))
                value = AskFont((Font)value);
            else
            {
                MessageBox.Show("Unsupported type: " + type.FullName, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SettingsManager.Set(key, value);

            if (type == typeof(bool) && key == "darkMode")
            {
                DarkModeProvider.SetDarkModeEnabled((bool)value);
            }

            listView1.SelectedItems[0].SubItems[2].Text = value.ToString();
        }

        private int AskInt(int value)
        {
            using (var d = new NumberInputDialog(value, int.MinValue, int.MaxValue))
            {
                if (d.ShowDialog() == DialogResult.OK)
                    return d.Value;
                return value;
            }
        }

        private string AskString(string value)
        {
            using (var d = new TextInputDialog(value))
            {
                if (d.ShowDialog() == DialogResult.OK)
                    return d.Value;
                return value;
            }
        }

        private Color AskColor(Color value)
        {
            using (var d = new MColorPicker()
            {
                Color = value
            })
            {
                if (d.ShowDialog() == DialogResult.OK)
                    return d.Color;
                return value;
            }
        }

        private Font AskFont(Font value)
        {
            using (var d = new MFontPicker()
            {
                Font = value
            })
            {
                if (d.ShowDialog() == DialogResult.OK)
                    return d.Font;
                return value;
            }
        }

        private void AdvancedSettings_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

            label2.ForeColor = dark ? Color.White : Color.FromArgb(255, 0, 51, 153);

            richTextLabel1.BackColor = dark ? Color.FromArgb(255, 56, 56, 56) : SystemColors.Window;
            richTextLabel1.ForeColor = ForeColor;

            checkBox1.FlatStyle = dark ? FlatStyle.Standard : FlatStyle.System;

            ControlScheduleSetDarkMode(checkBox1, dark);
            ControlScheduleSetDarkMode(button1, dark);
            ControlScheduleSetDarkMode(listView1, dark);
            listView1.SetDark(dark);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            splitContainer1.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count < 1 || listView1.SelectedItems.Count < 1)
            {
                richTextLabel1.Text = "";
                return;
            }

            var index = listView1.SelectedIndices[0];
            if (index < 0 || index >= listView1.Items.Count)
            {
                richTextLabel1.Text = "";
                return;
            }

            var key = listView1.SelectedItems[0].Text;
            if (!propertyDescriptions.ContainsKey(key))
            {
                richTextLabel1.Text = "";
                return;
            }

            richTextLabel1.Rtf = RichTextLabel.ParseFormattedString(propertyDescriptions[key]);
        }
    }
}
