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

            //Thread thread = new Thread(TimerTask);
            //thread.Start();

            Form1 main = new Form1();
            main.Shown += main_Shown;

            //while (count <= 2) ;
            //splashscreen.Hide();
            Application.Run(main);
        }

        static void main_Shown(object sender, EventArgs e)
        {
            // Hide the splashscreen. 
            //Thread.Sleep(1000);
            //while (count <= 2) ;
        }

        private static void TimerTask()
        {
            while (count <= 2)
            {
                Thread.Sleep(1000);//����1000ms�A�]�N�O1��
                count++;
            }
        }

    }
}
