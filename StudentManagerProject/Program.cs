using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagerProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Console.WriteLine("WTF");
            // roi ok doi t xiu
           //la sao, ong chon may cai do la gi
           // mai t giai thich cho ok
            Console.WriteLine("Test again");
        }
    }
}
