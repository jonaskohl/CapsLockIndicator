/*
 * Created 09.07.2017 18:16
 * 
 * Copyright (c) Jonas Kohl <http://jonaskohl.de/>
 */
using System;
using System.Threading;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
	internal sealed class Program
	{
        // Store the main form in a variable
        public static MainForm _mainForm;

        // Create a mutex to check if an instance is already running
        static Mutex mutex = new Mutex(true, "{6f54c357-0542-4d7d-9225-338bc3cd7834}");
        [STAThread]
		private static void Main(string[] args)
		{
            if (mutex.WaitOne(TimeSpan.Zero, true)) // No instance is open
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                _mainForm = new MainForm();
                Application.Run(_mainForm);

                // Release the mutex
                mutex.ReleaseMutex();
            }
            else // An instance is already open
            {
                if (_mainForm.isHidden)
                {
                    MessageBox.Show("An instance is already open!");
                }
                else
                {
                    _mainForm.Show();
                    _mainForm.Focus();
                }
            }
		}
	}
}
