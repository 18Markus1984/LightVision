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
    public partial class Kacheln : UserControl
    {

        private Pixel[,] pixel;             //Zweidimensionales Array für die Speicherung der Pixel Position und der Farbe 
        private bool onClick;               //speichert, ob die Linke-Maus gedrückt ist oder nicht
        private Color backColorButtons;     //die Farbe, die beim ColorDialog ausgewählt ist
        private bool fill;                  //ob der Fill-Tool Modus aktiviert ist
        private Color clickedButton;        //die Farbe die in dem Bereich ist, um den Bereich zu füllen
        
        protected int length = 24;
        protected int height = 8;
        private LightVision_Base mw;
        public ComboBox cbText;


        public Kacheln(LightVision_Base mw)
        {
            InitializeComponent();
            AddButtons();
            Random r = new Random();        
            colorDialog1.Color = Color.FromArgb(r.Next(0, 256),r.Next(0, 256), r.Next(0, 256));     //Eine zufällige Farbe am Anfang für einen spaßigen Start ;)
            bt_Color.BackColor = colorDialog1.Color;
            backColorButtons = colorDialog1.Color;
            this.mw = mw;
            cbText = cb_SelectedPanal;
            reloadComboBox();
        }

        public void reloadComboBox()
        {
            cb_SelectedPanal.Items.Clear();
            foreach (Panel p in mw.savedPanels)
            {
                cb_SelectedPanal.Items.Add(p.name);
            }
        }

        private void AddButtons()       //Fügt 280 Pixel hinzu
        {
            pixel = new Pixel[length, height]; 
            onClick = false;

            for (int k = 0; k < height; k++)
            {
                for (int i = 0; i < length; i++)
                {

                    pixel[i, k] = new Pixel(i * 30, k * 30, 30);
                }
            }
            this.DoubleBuffered = true;             //damit die refresh rate höher ist
            this.MouseMove += kachel_MouseMove;     //da man nicht hover und mousedown gleichzeitig als event verwenden kann mussten wir überprüfen, ob sich die Maus bewegt und über einem der Rechtecken befindet
            this.fill = false;                      //fill-Modus deaktiviert
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

        /// <summary>
        /// Event wenn sich die Maus bewegt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kachel_MouseMove(object sender, MouseEventArgs e)                          
        {
            if (onClick && cb_SelectedPanal.Text != "")                                                                        //die Licke-Maus-Taste muss gedrückt sein
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

        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            base.OnPaint(e);
            foreach (Pixel p in this.pixel)                     //Es werden alle Pixel durchgegangen und diese malen sich dann selber
                p.Render(e.Graphics);
        }

        /// <summary>
        /// wird für das malen bzw. hinterherziehen und fill tool verwendet
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)     
        {
            if (cb_SelectedPanal.Text != "")
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

        /// <summary>
        /// Die Leinwand wird weiß gemacht/ resetet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)    
        {
            foreach (var item in pixel)
            {
                item.Color = Color.White;
            }    
            this.Refresh();
        }

        private void bt_Speichern_Click(object sender, EventArgs e)     //Die Leinwand wird gespeichert
        {
            if (cb_SelectedPanal.Text != "")
            {
                List<int> colors = new List<int>();
                /*foreach (var item in pixel)
                {
                    colors.Add(item.Color.ToArgb());
                }*/

                int k = 0;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < length; i++)
                    {

                        colors.Add(pixel[i, j].Color.ToArgb());
                        k += 1;
                    }
                }
                mw.savedPanels[cb_SelectedPanal.SelectedIndex].colors = colors;
                mw.savedPanels[cb_SelectedPanal.SelectedIndex].showtime = Convert.ToDouble(tb_showtime.Text);
                mw.uploadPanels();
                MessageBox.Show("Speichern erfolgreich!");
            }
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
            if(tb_NamePanel.Text != "")
            {
                string name = tb_NamePanel.Text;
                Panel newP = new Panel(name);
                mw.savedPanels.Add(newP);
                cb_SelectedPanal.Items.Add(newP.name);
                tb_NamePanel.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPanel(mw.savedPanels[cb_SelectedPanal.SelectedIndex]);
        }

        private void bt_Löschen_Click(object sender, EventArgs e)
        {
            mw.savedPanels.Remove(mw.savedPanels[cb_SelectedPanal.SelectedIndex]);
            reloadComboBox();
        }
    }
}
