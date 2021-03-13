using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace LightVisionSettings
{
    public partial class Loading : Form
    {
        static Form loadingForm;
        private delegate void CloseDelegate();

        public Loading()
        {
            InitializeComponent();
        }

        static public void ShowLoadingScreen()      //die startische Methode wird in der Programm Main ausgeführt
        {
            loadingForm = new Loading();
            Thread t = new Thread(new ThreadStart(Loading.ShowForm));       //die MainWindow Form wird geladen
            t.Start();      //der Thread wird gestartet
        }

        private static void ShowForm()
        {
            if(loadingForm != null)
            {
                Application.Run(loadingForm);
            }
        }

        static public void CloseForm()
        {
            loadingForm.Invoke(new CloseDelegate(CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            if(loadingForm != null)
            {
                loadingForm.Close();
                loadingForm = null;
            }
        }
    }
}
