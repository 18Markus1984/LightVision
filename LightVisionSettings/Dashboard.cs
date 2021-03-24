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
        public List<SmallKachel> kacheln;
        public List<System.Windows.Forms.Panel> panels;
        public bool onclick = false;
        private LightVision_Base mw;

        public Dashboard(LightVision_Base mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        public void DashboardPanels()
        {
            if (kacheln != null)       
            {
                foreach (var item in kacheln)
                {
                    Controls.Remove(item);
                }
                foreach (var item in panels)
                {
                    Controls.Remove(item);
                }
            }
            kacheln = new List<SmallKachel>();
            panels = new List<System.Windows.Forms.Panel>();
            CreatePanel();

            for (int i = 0; i < mw.savedPanels.Count; i++)      //Für jedes Panel und Animation wird eine Kachel erstellt, die man bewegen kann
            {
                SmallKachel s = new SmallKachel(10, mw.savedPanels[i].colors, 8, 24);
                s.MouseDown += MouseDown;
                s.MouseMove += MouseMove;
                s.MouseUp += MouseUp;
                s.DoubleClick += DoubleClick;
                kacheln.Add(s);
                s.Width = 240;
                s.Height = 80;
                s.Location = panels[i].Location;
                s.Cursor = Cursors.Hand;
                s.LocationChanged += PostionChanged;
                s.matchingPanel = i;
                Controls.Add(s);
                s.BringToFront();
            }

            for (int i = mw.savedPanels.Count; i < mw.savedPanels.Count + mw.savedAnimations.Count; i++)
            { 
                SmallKachel s = new SmallKachel(10, mw.savedAnimations[i- mw.savedPanels.Count].animation, 8, 24,mw);
                s.MouseDown += MouseDown;
                s.MouseMove += MouseMove;
                s.MouseUp += MouseUp;
                s.DoubleClick += DoubleClick;
                kacheln.Add(s);
                s.Width = 240;
                s.Height = 80;
                s.Location = panels[i].Location;
                s.Cursor = Cursors.Hand;
                s.LocationChanged += PostionChanged;
                s.matchingPanel = i- mw.savedPanels.Count;
                Controls.Add(s);
                s.BringToFront();
            }

        }

        private void CreatePanel()  //Es sollen mehrere Panels erstellt werden, die als Lagerbehälter für die Panels gelten. Dann überprüfe ich wenn sich ein Panel bewegt einfach die Distance zu einem anderen Position eines Panels, wenn der Benutzer das PAnel nicht mehr mit der Linken Maustaste festhält und setze es an diese Position
        {
            int spalten = (mw.savedPanels.Count + mw.savedAnimations.Count) % 3;
            int reihen = (mw.savedPanels.Count + mw.savedAnimations.Count) / 3;

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
                    panel.Location = new Point(7 + k * 245, 20+i*85);
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
                    panel.Location = new Point(7 + z * 245, 20 + reihen * 85);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panels.Add(panel);
                    Controls.Add(panel);
                }
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)     //Wird bei den Kacheln benutzt, dass diese der Position der Maus gesetzt wird
        {
            SmallKachel kachel = (SmallKachel)sender;
            if (e.Button == MouseButtons.Left)
            {
                onclick = true;
                kachel.mouseDown = e.Location;
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)     //Wird benutzt, das wenn die Mausgedrückt ist und sich bewegt die Position der Kachel auf die der Maus zu setzen
        {
            SmallKachel kachel = (SmallKachel)sender;
            if (onclick)
            {
                kachel.Left += e.X - kachel.mouseDown.X;
                kachel.Top += e.Y - kachel.mouseDown.Y;
            }

        }

        private void PostionChanged(object sender, EventArgs e)     //Wenn sich eine Kachel bewegt hat
        {
            SmallKachel s = (SmallKachel)sender;
            s.moved = true;
        }

        private void MouseUp(object sender, MouseEventArgs e)       //Wenn die Maus nicht mehr nach unten gedrückt wird
        {
            onclick = false;
            SmallKachel s = (SmallKachel)sender;

            if (s.moved == true)        //Wenn sich die Kachel bewegt hat; Hier wird nach der nahsten boden Kachel gesucht 
            {
                int nearestPanel = 0;       //Index im Array
                double length = 10;

                for (int i = 0; i < panels.Count; i++)
                {
                    for (int t = 0; t < panels.Count; t++)
                    {
                        if (panels[i].Location != kacheln[t].Location)      
                        {
                            //Vektor zwischen den Koordinaten wird berechnet
                            int x = s.Location.X - panels[i].Location.X;
                            int y = s.Location.Y - panels[i].Location.Y;
                            //Hier wird überprüft, ob der Vektor länger ist als der andere (Size Matter)
                            if (length > Math.Sqrt(x * x + y * y))
                            {
                                length = Math.Sqrt(x * x + y * y);
                                nearestPanel = i;
                            }
                        }
                    }
                }
                if (length <= 9.0)      //Wenn der Vektor kleiner gleich 9 ist snappt die Kachel in die Position des Bodenpanels herein
                {
                    s.Location = panels[nearestPanel].Location;
                    s.moved = false;
                }
            }
        }

        private List<Panel> createList()        //Alle Panel werden in einer Liste gespeichert und Panel werden von ihrer Animation getrennt
        {
            List<Panel> p = new List<Panel>();
            for (int i = 0; i < panels.Count; i++)
            {
                foreach (var item in kacheln)
                {
                    if (item.Location == panels[i].Location)
                    {
                        if (item.thisISAnAnimation)
                        {
                            foreach (Panel panel in mw.savedAnimations[item.matchingPanel].animation)       //Alle Panel werden durchgegangen und die Panel in der Liste gespeichert
                            {
                                panel.wiederholungen = mw.savedAnimations[item.matchingPanel].wiederholungen;
                                p.Add(panel);
                            }
                        }
                        else
                        {
                            p.Add(mw.savedPanels[item.matchingPanel]);
                        }
                    }
                }
            }
            return p;
        }

        private void bt_Speichern_Click(object sender, EventArgs e)     //Die aktuelle Reihenfolge der Elemente auf dem Dashboard wird gespeichert
        {
            List<Panel> puffer = mw.savedPanels;
            List<Panel> p = createList();
            int number = 0;
            foreach (SmallKachel item in kacheln)
            {
                if (item.thisISAnAnimation)
                {
                    number += item.panels.Length;
                }
            }
            if (p.Count == mw.savedPanels.Count+number)     //Es wird geprüft, dass auch die Werte übereinstimmten
            {
                mw.savedPanels = p;
                mw.uploadPanels();
                MessageBox.Show("Speichern erfolgreich!");
                mw.savedPanels = puffer;
                mw.kacheln.reloadComboBox();
                return;
            }
            MessageBox.Show("Speichern fehlgeschlagen!");
        }

        private new void DoubleClick(object sender, EventArgs e)        //Wenn die Kachel gedoppelklickt wird, wird Animator/Editor geöffnet, dementsprechend, was es für ein Element ist
        {
            SmallKachel kachel = (SmallKachel)sender;
            if (kachel.thisISAnAnimation)
            {
                mw.animator.BringToFront();
                mw.animator.numberOfPanels = kachel.panels.Length;
                mw.animator.AddButton();
                mw.animator.AddCircles();
                mw.animator.reloadComboBox();
                mw.animator.comboBoxText.SelectedIndex = kachel.matchingPanel;
                mw.animator.RealoadAnimator();
                mw.buttons[1].BackColor = mw.menuColor;
                mw.buttons[3].BackColor = Color.Transparent;
                mw.animator.comboBoxText.Text = mw.savedAnimations[kachel.matchingPanel].name;
            }
            else
            {
                mw.kacheln.cbText.Text = mw.savedPanels[kachel.matchingPanel].name;
                mw.kacheln.BringToFront();
                mw.buttons[0].BackColor = mw.menuColor;
                mw.buttons[3].BackColor = Color.Transparent;
            }
        }
    }
}
