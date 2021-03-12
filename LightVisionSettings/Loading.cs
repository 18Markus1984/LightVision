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
        public Loading()
        {
            InitializeComponent();
        }
        static Form loadingForm;
        private delegate void CloseDelegate();
        
    
        static public void ShowLoadingScreen()
        {
            loadingForm = new Loading();
            Thread t = new Thread(new ThreadStart(Loading.ShowForm));
            t.Start();
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
