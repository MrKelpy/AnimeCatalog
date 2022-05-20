using System;
using System.Windows.Forms;

namespace PFM5
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
            Application.Run(new LoadingScreen());
            Application.Run(new AnimeListGUI());
        }
    }
}