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
        public List<Animation> savedAnimations; //Speichert alle erstellten Animation


        //Alle UserControl Panels
        public Dashboard dashboard;
        public Kacheln kacheln;
        public Settings settings;
        public Vorlagen vorlagen;
        public Animator animator;


        //Werte und dlls für das Bewegen einer borderlosen form und Abrundung von Regions
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
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
            savedAnimations = new List<Animation>();
            dashboard = new Dashboard(this);
            p_Content.Controls.Add(dashboard);

            kacheln = new Kacheln(this);
            p_Content.Controls.Add(kacheln);
            kacheln.BringToFront();

            settings = new Settings(this);
            p_Content.Controls.Add(settings);

            vorlagen = new Vorlagen(this);
            p_Content.Controls.Add(vorlagen);

            animator = new Animator(this,25,8,24);
            p_Content.Controls.Add(animator);

            buttons = new List<Button>() {bt_Editor, bt_Animator, bt_Templates, bt_Dashboard, bt_Settings };

            timer1.Start();

            design();
        }


        /// <summary>
        /// Alle Befehle, die beim start der Form ausgeführt werden und hauptsächlich kosmetischer Art sind.
        /// </summary>
        private void design()
        {
            settings.contentColor = contentColor;
            settings.menuColor = menuColor;

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            bt_Editor.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Templates.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Settings.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Dashboard.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Animator.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));

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
            if (dashboard.kacheln != null)
            {
                foreach (SmallKachel small in dashboard.kacheln)
                {
                    if (small.thisISAnAnimation)
                    {
                        small.thread.Abort();
                    }
                }
            }
            this.Close();
        }

        private void bt_Editor_Click(object sender, EventArgs e)
        {
            kacheln.BringToFront();
            ButtonColorClick(sender);
        }

        private void bt_templates_Click(object sender, EventArgs e)
        {
            vorlagen.BringToFront();
            ButtonColorClick(sender);
        }

        private void bt_Dashboard_Click(object sender, EventArgs e)
        {
            dashboard.BringToFront();
            ButtonColorClick(sender);
            dashboard.DashboardPanels();
        }

        private void bt_Settings_Click(object sender, EventArgs e)
        {
            settings.BringToFront();
            ButtonColorClick(sender);
        }
        private void bt_Animator_Click(object sender, EventArgs e)
        {
            animator.BringToFront();
            ButtonColorClick(sender);
            animator.AddButton();
            animator.AddCircles();
            animator.Refresh();
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
            animator.BackColor = menuColor;
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

        private void p_Content_Paint(object sender, PaintEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
            this.Focus(); this.Show();
        }
    }
}
