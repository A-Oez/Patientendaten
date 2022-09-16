using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientenDaten
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

            try
            {
                Application.Run(new Patienten_Verwaltung());
            }
            catch
            {
                MessageBox.Show("Anwendung kann nicht gestartet werden, Serververbindung prüfen!");
            }
            
        }
    }
}
