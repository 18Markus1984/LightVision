using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightVisionSettings
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Loading.ShowLoadingScreen();
            LightVision_Base mainForm = new LightVision_Base();
            Loading.CloseForm();
            Application.Run(mainForm);
        }
    }
}
