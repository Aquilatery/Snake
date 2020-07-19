using System;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Snake
{
    static class Snake
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>

        private static readonly Mutex Mutex = new Mutex(true, "{" + ((GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute), false)).Value + "}");
        
        [STAThread]
        static void Main()
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