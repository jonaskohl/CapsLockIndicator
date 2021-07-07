using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class RichTextLabel : RichTextBox
    {
        public RichTextLabel()
        {
            ReadOnly = true;
            BorderStyle = BorderStyle.None;
            TabStop = false;
            Cursor = Cursors.Default;
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.UserMouse, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            MouseEnter += delegate (object sender, EventArgs e)
            {
                Cursor = Cursors.Default;
            };
        }

        public static string ParseFormattedString(string str)
        {
            var parts = new List<TextRun>();

            var buffer = new StringBuilder();
            var insideFormatExpression = false;
            var currentFormat = Format.Regular;
            int i = 0;
            while (i < str.Length)
            {
                if (!insideFormatExpression && str.Length - i >= 5 && (str.Substring(i, 4) == ":i:{" || str.Substring(i, 4) == ":b:{"))
                {
                    parts.Add(new TextRun() { Format = currentFormat, Text = buffer.ToString() });
                    buffer.Clear();
                    insideFormatExpression = true;
                    currentFormat = str[i + 1] == 'b' ? Format.Bold : Format.Italic;
                    i += 4;
                    goto add;
                }
                if (insideFormatExpression && str[i] == '}')
                {
                    parts.Add(new TextRun() { Format = currentFormat, Text = buffer.ToString() });
                    buffer.Clear();
                    insideFormatExpression = false;
                    currentFormat = Format.Regular;
                    goto inc;
                }

            add:
                buffer.Append(str[i]);

            inc:
                ++i;
            }
            parts.Add(new TextRun() { Format = currentFormat, Text = buffer.ToString() });

            var rtf = new StringBuilder();
            rtf.Append(@"{\rtf1\ansi ");
            foreach (var part in parts)
            {
                if (part.Format == Format.Bold)
                {
                    rtf.Append(@"\b ");
                }
                else if (part.Format == Format.Italic)
                {
                    rtf.Append(@"\i ");
                }

                rtf.Append(EscapeRtf(part.Text));

                if (part.Format == Format.Bold)
                {
                    rtf.Append(@"\b0 ");
                }
                else if (part.Format == Format.Italic)
                {
                    rtf.Append(@"\i0 ");
                }
            }
            rtf.Append("}");
            return rtf.ToString();
        }

        private static string EscapeRtf(string input)
        {
            var backslashed = new StringBuilder(input);
            backslashed.Replace(@"\", @"\\");
            backslashed.Replace(@"{", @"\{");
            backslashed.Replace(@"}", @"\}");

            var sb = new StringBuilder();
            foreach (var character in backslashed.ToString())
            {
                if (character <= 0x7f)
                    sb.Append(character);
                else
                    sb.Append("\\u" + Convert.ToUInt32(character) + "?");
            }
            return sb.ToString();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x204) return; // WM_RBUTTONDOWN
            if (m.Msg == 0x205) return; // WM_RBUTTONUP
            base.WndProc(ref m);
        }


        enum Format { Regular, Bold, Italic }
        struct TextRun
        {
            public string Text;
            public Format Format;
        }
    }
}
