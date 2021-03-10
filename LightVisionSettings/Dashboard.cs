using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LightVisionSettings
{
    //Hier sollen dann alle Kacheln angezeigt werden, die gerade auf dem Server laufen
    public partial class Dashboard : UserControl
    {
        private List<Panel> savedPanels = new List<Panel>(); //Speichert alle erstellten Panels
        public List<SmallKachel> kacheln;
        public List<System.Windows.Forms.Panel> panels;
        public bool onclick = false; 

        public Dashboard()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Dashboard_TabIndexChanged(object sender, EventArgs e)
        {
            savedPanels = downloadPanels();
            kacheln = new List<SmallKachel>();
            panels = new List<System.Windows.Forms.Panel>();
            CreatePanel();

            for (int i = 0; i < savedPanels.Count; i++)
            {
                SmallKachel s = new SmallKachel(10, savedPanels[i].colors, 8, 24);
                s.MouseDown += MouseDown;
                s.MouseMove += MouseMove;
                s.MouseUp += MouseUp;
                kacheln.Add(s);
                Controls.Add(s);
                s.BringToFront();
                s.Width = 240;
                s.Height = 80;
                s.Location = panels[i].Location;
            }
            
        }

        private void CreatePanel()  //Es sollen mehrere Panels erstellt werden, die als Lagerbehälter für die Panels gelten. Dann überprüfe ich wenn sich ein Panel bewegt einfach die Distance zu einem anderen Position eines Panels, wenn der Benutzer das PAnel nicht mehr mit der Linken Maustaste festhält und setze es an diese Position
        {
            int spalten = savedPanels.Count % 3;
            int reihen = savedPanels.Count / 3;

            for (int i = 0; i < reihen; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                    Label l = new Label();
                    l.Location = new Point(240 / 2 - l.Width/8, 80 / 2 - l.Height / 2);
                    l.ForeColor = Color.White;
                    l.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                    l.Text = "" + (k + i * 3 + 1);
                    panel.Controls.Add(l);
                    panel.Size = new Size(240, 80);
                    panel.Location = new Point(5 + k * 245, 20+i*85);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panels.Add(panel);
                    Controls.Add(panel);
                }
            }
            if (spalten != 0)
            {
                for (int z = 0; z < spalten; z++)
                {
                    System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                    Label l = new Label();
                    l.Location = new Point(240 / 2 - l.Width / 8, 80 / 2 - l.Height / 2);
                    l.ForeColor = Color.White;
                    l.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                    l.Text = "" + (z + reihen * 3 + 1);
                    panel.Controls.Add(l);
                    panel.Size = new Size(240, 80);
                    panel.Location = new Point(5 + z * 245, 20 + reihen * 85);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panels.Add(panel);
                    Controls.Add(panel);
                }
            }
        }

        private void uploadPanels()
        {
            Client client = new Client("135.181.35.212", 65432);
            client.SendPanel(savedPanels);
        }

        private List<Panel> downloadPanels()
        {
            Client client = new Client("135.181.35.212", 65432);
            return client.GetPanel();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            SmallKachel kachel = (SmallKachel)sender;
            if (e.Button == MouseButtons.Left)
            {
                onclick = true;
                kachel.mouseDown= e.Location;
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            SmallKachel kachel = (SmallKachel)sender;
            if (onclick)
            {
                kachel.Left += e.X - kachel.mouseDown.X;
                kachel.Top += e.Y - kachel.mouseDown.Y;
            }

        }

        private void PostionChanged(object sender)
        {

        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            onclick = false;
            for (int i = 0; i < savedPanels.Count; i++)
            {
                
            }
        }
    }
}
