using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Sections S = new Sections("Sections");
            Groups G = new Groups("Groups");
            Kids K = new Kids("Kids");
            Application.Run(new FormSections());
        }
    }
}
