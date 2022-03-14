using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace gui
{
    static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static int count = 1;

        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 main = new Form1();
            Application.Run(main);
        }
    }
}
