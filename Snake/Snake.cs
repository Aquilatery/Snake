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

        private static readonly Mutex Mutex = new(true, ((GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute), false)).Value);

        [STAThread]
        private static void Main()
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
#if NETCOREAPP3_1 || NET5_0 || NET6_0 || NET7_0
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
                Application.SetCompatibleTextRenderingDefault(false);
                Control.CheckForIllegalCrossThreadCalls = false;
                Application.Run(new Game());
                Application.DoEvents();
                Mutex.ReleaseMutex();
            }
        }
    }
}