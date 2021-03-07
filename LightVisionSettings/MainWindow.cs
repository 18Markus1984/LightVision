using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LightVisionSettings
{
    public partial class LightVision_Base : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public LightVision_Base()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


            p_Slider.Location = new Point(0, 126);


        }

        //public Client c = new Client("135.181.35.212", 1337);

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Wecker_Click(object sender, EventArgs e)
        {
            bt_Editor.BackColor = Color.FromArgb(30, 30, 30);
            p_Slider.Location = new Point(0, 126);
            kacheln1.BringToFront();
            p_Slider.BringToFront();
        }

        private void bt_Kacheln_Click(object sender, EventArgs e)
        {
            bt_Kacheln.BackColor = Color.FromArgb(30, 30, 30);
            p_Slider.Location = new Point(0, 166);
            
        }

        private void bt_Einstellungen_Click(object sender, EventArgs e)
        {
            bt_Dashboard.BackColor = Color.FromArgb(30, 30, 30);
            p_Slider.Location = new Point(0, 206);
            dashboard1.BringToFront();
            p_Slider.BringToFront();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)   //Methode zum bewegen der RandlosenForm
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bt_Enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.FromArgb(64, 64, 64);
        }
    }
}
