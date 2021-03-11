﻿using System;
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
    public partial class Animator : UserControl 
    {
        private LightVision_Base mw;
        private int height;
        private int length;
        private int size;
        private Pixel[,] pixel;
        private CircleAnimator[] circles;
        

        private bool onClick;               //speichert, ob die Linke-Maus gedrückt ist oder nicht
        private Color backColorButtons;     //die Farbe, die beim ColorDialog ausgewählt ist
        private bool fill;                  //ob der Fill-Tool Modus aktiviert ist
        private Color clickedButton;        //die Farbe die in dem Bereich ist, um den Bereich zu füllen
        private int selectedPanel = 0;

        private int numberOfPanels = 5;

        public Animator(LightVision_Base mw, int size, int height, int length)
        {
            InitializeComponent();
            
            this.mw = mw;
            this.size = size;
            this.height = height;
            this.length = length;
            this.Size = new Size(747, 458);
            AddButton();
            AddCircles();
            Random r = new Random();
            colorDialog1.Color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));     //Eine zufällige Farbe am Anfang für einen spaßigen Start ;)
            bt_Color.BackColor = colorDialog1.Color;
            backColorButtons = colorDialog1.Color;

        }

        public void reloadComboBox()
        {
            cb_SelectedPanal.Items.Clear();
            foreach (Animation a in mw.savedAnimations)
            {
                cb_SelectedPanal.Items.Add(a.name);
            }
        }

        public void AddButton()
        {
            pixel = new Pixel[length, height];
            int d = 0;
            for (int i = 0; i < height; i++)
            {
                for (int m = 0; m < length; m++)
                {
                    pixel[m, i] = new Pixel(m * size + ((747-25*25)/2), i * size + 30, size);

                }
            }
            this.DoubleBuffered = true;             //damit die refresh rate höher ist
            this.MouseMove += kachel_MouseMove;     //da man nicht hover und mousedown gleichzeitig als event verwenden kann mussten wir überprüfen, ob sich die Maus bewegt und über einem der Rechtecken befindet
            this.fill = false;                      //fill-Modus deaktiviert

            this.Refresh();
        }

        private void AddCircles()
        {
            circles = new CircleAnimator[numberOfPanels];
            for (int i = 0; i < numberOfPanels; i++)
            {
                circles[i] = new CircleAnimator(10, Color.White, ((747 - 24 * 25) / 2 + 55) + i * (24 * 25 / numberOfPanels), 20);

            }
        }

        private void loadPanel(Panel selectedPanel)
        {
            int k = 0;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < length; i++)
                {
                    pixel[i, j].Color = Color.FromArgb(selectedPanel.colors[k]);
                    k += 1;
                }
            }
            tb_showtime.Text = Convert.ToString(selectedPanel.showtime);
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            base.OnPaint(e);
            foreach (Pixel p in this.pixel)                     //Es werden alle Pixel durchgegangen und diese malen sich dann selber
            {
                p.Render(e.Graphics);
            }
            foreach (CircleAnimator c in circles)
            {
                c.Render(e.Graphics);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int x = e.X / 30;                                      //Die x und y Koordinaten werden durch 25 geteilt, damit wir die Pixel Koordianten in Array-Positionen umrechnen können
            int y = e.Y / 30;

            if (fill && x < length && x >= 0 && y < height && y >= 0)       //Die x und y Werte sollten nicht größer als 28/10 und kleiner als 0 sein, da e die Werte als 0 bis 10 ausgibt
            {
                clickedButton = pixel[x, y].Color;                  //Die Farbe auf das geklickte Feld wird gespeichert, da man ja wissen muss welche Fläche, umgefärbt werden soll
                fillButtons(clickedButton, x, y);                                  //Die Rekursive Funktion wird aufgerufen
                this.Refresh();                                     //Die gemalten Rechtecke werden geudatet
                return;                                             //Methode wird verlassen
            }

            onClick = true;                                         //Der Button wird gedrückt

            foreach (Pixel p in this.pixel)                         //Falls nur ein Knopf gedrückt wird werden alle Rechteckpositionen durchgegangen, um zu überprüfen ob auf jenes gedrückt wurde
            {
                if (e.X - 10 > p.X && e.X - 10 < p.X + p.Size && e.Y - 10 > p.Y && e.Y - 10 < p.Y + p.Size)
                {
                    p.Color = colorDialog1.Color;                   //Farbe wird für den Pixel gesetzt
                    this.Refresh();                                 //alle Rechtecke werden neu gezeichnet
                }
            }


            int counter = 0;
            foreach (CircleAnimator c in circles)
            {
                if (e.X +10 >= c.X && e.X < c.X + c.Radius && e.Y+10 >= c.Y && e.Y < c.Y + c.Radius)
                {
                    savePanel();
                    selectedPanel = counter;
                    c.Color = mw.contentColor;
                    label1.Text = "" + counter;
                    tb_showtime.Text = ""+mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel].showtime;
                    loadPanel(mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel]);
                    foreach(CircleAnimator ci in circles)
                    {
                        if (ci != c)
                        {
                            ci.Color = Color.White;
                        }
                    }
                    this.Refresh();
                    break;
                }
                counter++;
            }
            
        }

        private void savePanel()
        {
            List<int> puffer = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 24; m++)
                {
                    puffer.Add(pixel[m,i].Color.ToArgb());
                }
            }

            if (tb_showtime.Text != "")
            {
                mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel].colors = puffer;
                mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel].showtime = Convert.ToDouble(tb_showtime.Text);
            }
        }

        private void kachel_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)                                                                        //die Licke-Maus-Taste muss gedrückt sein
            {
                foreach (Pixel p in this.pixel)
                {
                    if (e.X - 10 > p.X && e.X - 10 < p.X + p.Size && e.Y - 10 > p.Y && e.Y - 10 < p.Y + p.Size)    //Es wird überprüft über welchem Pixel sich die Maus bewegt
                    {
                        p.Color = colorDialog1.Color;                                           //Die Hintergrundfarbe des entsprechenden Pixel wird auf die Ausgewählte geändert
                        this.Refresh();                                                         //Die Pixel Rechtecke werden neu gezeichnet
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)         //Wird aktiviert, wenn die Linke Maus Taste aufgehört wird zu drücken
        {
            base.OnMouseUp(e);
            onClick = false;                                        //der druckstatus der Maus wird geändert
        }

        private void bt_Color_Click_1(object sender, EventArgs e)       //Hier wird die Farbe zum Malen ausgewählt
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bt_Color.BackColor = colorDialog1.Color;
                backColorButtons = colorDialog1.Color;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (var item in pixel)
            {
                item.Color = Color.White;
            }
            this.Refresh();
        }

        private void Fill_Click(object sender, EventArgs e)     //Methode für den Fill-Modus
        {
            if (fill)               //ändert die Farbe das der Benutzer sieht, dass er den Fill-Modus aktiviert hat
            {
                bt_fill.BackColor = SystemColors.Control;
            }
            else
            {
                bt_fill.BackColor = Color.LightGray;
            }
            fill = !fill;           //beim drücken auf den Knopf wird die aktivität des Modus geändert
        }

        public void fillButtons(Color original, int x, int y)       //Die rekursive Funktion für die Ausfüllung der Fläche verwendet
        {
            if (x < length && x >= 0 && y < height && y >= 0 && pixel[x, y].Color == original)
            {
                if (pixel[x, y].Color == backColorButtons)
                    return;
                pixel[x, y].Color = backColorButtons;   //Die Farbe des aktuelle betrachteten Pixels wird geändert
                fillButtons(original, x, y + 1);                  //nach oben
                fillButtons(original, x + 1, y);                  //nach rechts
                fillButtons(original, x, y - 1);                  //nach unten
                fillButtons(original, x - 1, y);                  //nach links    
            }
        }

        private void bt_NewPanel_Click(object sender, EventArgs e)
        {
            if (tb_NamePanel.Text != "")
            {
                string name = tb_NamePanel.Text;
                Animation animation = new Animation(name,numberOfPanels);
                animation.numberOfPanels = (int)number.Value;
                numberOfPanels = (int)number.Value;
                mw.savedAnimations.Add(animation);
                cb_SelectedPanal.Items.Add(name);
                cb_SelectedPanal.Text = "";
                tb_NamePanel.Text = "";
                AddCircles();
            }
        }

        private void cb_SelectedPanal_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPanel = 0;
            circles[0].Color = mw.contentColor;
            foreach (CircleAnimator circle in circles)
            {
                if (circles[0] != circle)
                {
                    circle.Color = Color.White;
                }
            }
            loadPanel(mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel]);
        }
    }
}
