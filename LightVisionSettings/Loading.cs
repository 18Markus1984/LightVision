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
using System.Media;

namespace LightVisionSettings
{
    public partial class Loading : Form
    {
        static Form loadingForm;
        private delegate void CloseDelegate();
        private static SoundPlayer player;

        public Loading()
        {
            InitializeComponent();
        }

        static public void ShowLoadingScreen()      //die startische Methode wird in der Programm Main ausgeführt
        {
            player = new SoundPlayer();
            loadingForm = new Loading();
            Random rnd = new Random();

            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\Wartemusik"+rnd.Next(0,3)+".wav";
            player.Play();
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
                player.Stop();
                loadingForm.Close();
                loadingForm = null;
            }
        }
    }
}
