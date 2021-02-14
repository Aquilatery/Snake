using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Snake
{
    internal static class Snake
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>

        private static readonly Mutex Mutex = new Mutex(true, "{" + ((GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute), false)).Value + "}");

        [STAThread]
        private static void Main()
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Control.CheckForIllegalCrossThreadCalls = false;
                Application.Run(new Game());
                Mutex.ReleaseMutex();
            }
        }
    }
}