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
        //Werte für die Veränderung des Aussehens
        public Color menuColor = Color.FromArgb(43, 147, 72);
        public Color contentColor = Color.FromArgb(0, 127, 95);

        int buttonRadius = 35;
        int buttonOffsetLeft = 5;

        //Werte zum Arbeiten
        public List<Button> buttons;
        public List<Panel> savedPanels; //Speichert alle erstellten Panels


        //Alle UserControl Panels
        public Dashboard dashboard;
        public Kacheln kacheln;
        public Settings settings;
        public Vorlagen vorlagen;


        //Werte und dlls für das Bewegen einer borderlosen form und Abrundung von Regions
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

            savedPanels = downloadPanels();

            dashboard = new Dashboard(this);
            p_Content.Controls.Add(dashboard);

            kacheln = new Kacheln(this);
            p_Content.Controls.Add(kacheln);
            kacheln.BringToFront();

            settings = new Settings(this);
            p_Content.Controls.Add(settings);

            vorlagen = new Vorlagen(this);
            p_Content.Controls.Add(vorlagen);

            buttons = new List<Button>() {bt_Editor, bt_Kacheln, bt_Dashboard, bt_Settings };

            settings.contentColor = contentColor;
            settings.menuColor = menuColor;
            timer1.Start();

            design();
        }

        private void design()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            bt_Editor.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Dashboard.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Kacheln.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Settings.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));

            p_Slider.Location = new Point(0, 126);
            p_Slider.Enabled = true;
            bt_Editor.BackColor = menuColor;
        }

        public void uploadPanels()
        {
            Client client = new Client("135.181.35.212", 65432);
            client.SendPanel(savedPanels);
        }

        public List<Panel> downloadPanels()
        {
            Client client = new Client("135.181.35.212", 65432);
            return client.GetPanel();
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Editor_Click(object sender, EventArgs e)
        {
            //bt_Editor.BackColor = menuColor;
            p_Slider.Location = new Point(0, 126);
            kacheln.BringToFront();
            ButtonColorClick(sender);
        }

        private void bt_Kacheln_Click(object sender, EventArgs e)
        {
            //bt_Kacheln.BackColor = menuColor;
            p_Slider.Location = new Point(0, 166);
            vorlagen.BringToFront();
            ButtonColorClick(sender);
        }

        private void bt_Dashboard_Click(object sender, EventArgs e)
        {
            //bt_Dashboard.BackColor = menuColor;
            p_Slider.Location = new Point(0, 206);
            dashboard.BringToFront();
            ButtonColorClick(sender);
            dashboard.DashboardPanels();
        }

        private void bt_Settings_Click(object sender, EventArgs e)
        {
            //bt_Settings.BackColor = menuColor;
            p_Slider.Location = new Point(0, 246);
            settings.BringToFront();
            ButtonColorClick(sender);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)   //Methode zum bewegen der RandlosenForm
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ButtonColorClick(object sender)
        {
            Button b = (Button)sender;
            foreach (var item in buttons)
            {
                if (item != b)
                {
                    item.BackColor = Color.Transparent;
                }
                else
                {
                    item.BackColor = menuColor;
                }
            }
            p_Slider.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (settings.rgb)
            {
                Random rnd = new Random();
                int A = rnd.Next(0, 255);
                int R = rnd.Next(0, 255);
                int G = rnd.Next(0, 255);
                int B = rnd.Next(0, 255);
                label1.ForeColor = Color.FromArgb(A, R, G, B);
            }
            else
            {
                label1.ForeColor = Color.White;
            }

            ChangeColor();
        }

        private void ChangeColor()
        {
            menuColor = settings.menuColor;
            contentColor = settings.contentColor;

            settings.BackColor = menuColor;
            dashboard.BackColor = menuColor;
            kacheln.BackColor = menuColor;
            p_Content.BackColor = menuColor;
            vorlagen.BackColor = menuColor;
            foreach (var item in buttons)
            {
                if (item.BackColor != Color.Transparent)
                {
                    item.BackColor = menuColor;
                }
            }

            panel2.BackColor = contentColor;
            p_Nav.BackColor = contentColor;
        }
    }
}
