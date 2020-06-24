using System;
using System.Threading;
using System.Windows.Forms;

namespace Snake
{
    static class Snake
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex Mutex = new Mutex(true, "{329958c6-1088-48bc-84e4-abd0dd07ea69}");
        [STAThread]
        static void Main()
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Game());
                Mutex.ReleaseMutex();
            }
        }
    }
}