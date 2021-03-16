using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace LightVisionSettings
{
    public partial class Kacheln : UserControl
    {

        private Pixel[,] pixel;             //Zweidimensionales Array für die Speicherung der Pixel Position und der Farbe 
        private bool onClick;               //speichert, ob die Linke-Maus gedrückt ist oder nicht
        private Color backColorButtons;     //die Farbe, die beim ColorDialog ausgewählt ist
        private bool fill;                  //ob der Fill-Tool Modus aktiviert ist
        private Color clickedButton;        //die Farbe die in dem Bereich ist, um den Bereich zu füllen
        private System.Windows.Forms.Panel selectedColorPanel;  //Der ausgewählte Button der Color-Palette

        protected int length = 24;          //Pixel-Breite des Displays
        protected int height = 8;           //Pixel-Höhe des displays
        private LightVision_Base mw;        //Main Form mit allen anderen User Controll Panels
        public ComboBox cbText;             //ComboBox für bei dem augewählt wird welches Panel angezeigt wird(beinhaltet die Namen aller Panels)
        public string name = "";


        public Kacheln(LightVision_Base mw)     //
        {
            InitializeComponent();
            AddButtons();       //Die Pixels werden erstellt
            Random r = new Random();
            colorDialog1.Color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));     //Eine zufällige Farbe am Anfang für einen spaßigen Start ;)
            bt_Color1.BackColor = colorDialog1.Color;
            backColorButtons = colorDialog1.Color;
            this.mw = mw;
            cbText = cb_SelectedPanal;      //Die ComboBox wird auf cbText gesetzt, damit man von überall auf den cb_SelectedPanel.Text zugreifen kann
            reloadComboBox();               //Die Items der ComboBox werden geladen
        }

        public void reloadComboBox()        //Beim erstellen/Löschen von Panels muss der Inhalt der ComboBox angepasst werden
        {
            cb_SelectedPanal.Items.Clear();
            foreach (Panel p in mw.savedPanels)
            {
                cb_SelectedPanal.Items.Add(p.name);
            }
        }

        private void AddButtons()       //Fügt 192 Pixel hinzu
        {
            pixel = new Pixel[length, height]; //zweidimensionales Array mit der Höhe und Breite des Dispalays wird erstellt
            onClick = false;        //Die Variabele zur Prüfung, ob der User die Linke Maustaste drückt wird auf false gesetzt

            for (int k = 0; k < height; k++)
            {
                for (int i = 0; i < length; i++)
                {

                    pixel[i, k] = new Pixel(i * 30+3, k * 30, 30);        //Alle Buttons werden mit einer Breite und Höhe von 30 erstellt
                }
            }
            this.DoubleBuffered = true;     //damit die refresh rate höher ist
            this.MouseMove += kachel_MouseMove;     //da man nicht hover und mousedown gleichzeitig als event verwenden kann mussten wir überprüfen, ob sich die Maus bewegt und über einem der Rechtecken befindet
            this.fill = false;      //fill-Modus deaktiviert
        }

        private void loadPanel(Panel selectedPanel)     //Mit der Eingabe eines Panels werden dessen Farbdaten auf die jeweiligen Pixel übertragen
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
            tb_showtime.Text = Convert.ToString(selectedPanel.showtime);        //Die TextBox erhält die Information wie lange das Panel angezeigt werden soll
            this.Refresh();         //Die Graphis werden neue gemalt
        }

        private void kachel_MouseMove(object sender, MouseEventArgs e)       //Wird ausgelöst wenn sich die Maus bewegt                   
        {
            if (onClick && cb_SelectedPanal.Text != "")     //die Licke-Maus-Taste muss gedrückt sein
            {
                foreach (Pixel p in this.pixel)
                {
                    if (e.X - 10 > p.X && e.X - 10 < p.X + p.Size && e.Y - 10 > p.Y && e.Y - 10 < p.Y + p.Size)    //Es wird überprüft über welchem Pixel sich die Maus bewegt
                    {
                        p.Color = colorDialog1.Color;       //Die Hintergrundfarbe des entsprechenden Pixel wird auf die ausgewählte Farbe geändert
                        this.Refresh();     //Die Pixel Rechtecke werden neu gezeichnet
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            base.OnPaint(e);
            foreach (Pixel p in this.pixel)     //Es werden alle Pixel durchgegangen und diese malen sich dann mit der Render Methode selber
                p.Render(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)     //Wenn die Linke Maus gedrückt wird
        {
            if (cb_SelectedPanal.Text != "")        //Falls ein Panel in der ComboBox ausgewählt ist
            {
                base.OnMouseDown(e);
                int x = e.X / 30;       //Die x und y Koordinaten werden durch 30 geteilt, damit wir die Pixel Koordianten in Array-Positionen umrechnen können
                int y = e.Y / 30;

                if (fill && x < length && x >= 0 && y < height && y >= 0)       //Die x und y Werte sollten nicht größer als 28/10 und kleiner als 0 sein, da e die Werte als 0 bis 10 ausgibt
                {
                    clickedButton = pixel[x, y].Color;      //Die Farbe auf das geklickte Feld wird gespeichert, da man ja wissen muss welche Fläche, umgefärbt werden soll
                    fillButtons(clickedButton, x, y);       //Die Rekursive Funktion wird aufgerufen
                    this.Refresh();     //Die Rechtecke werden geudatet
                    return;         //Methode wird verlassen
                }

                onClick = true;     //Der Button wird gedrückt
                foreach (Pixel p in this.pixel)     //Falls nur ein Knopf gedrückt wird werden alle Rechteckpositionen durchgegangen, um zu überprüfen auf welches gedrückt wurde
                {
                    if (e.X - 10 > p.X && e.X - 10 < p.X + p.Size && e.Y - 10 > p.Y && e.Y - 10 < p.Y + p.Size)
                    {
                        p.Color = selectedColorPanel.BackColor;
                        //p.Color = colorDialog1.Color;       //Farbe wird für den Pixel gesetzt
                        this.Refresh();     //alle Rechtecke werden neu gezeichnet
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)     //Wird aktiviert, wenn die Linke Maus Taste aufgehört wird zu drücken
        {
            base.OnMouseUp(e);
            onClick = false;        //der druckstatus der Maus wird geändert
        }

        private void paletteChangeColor(object sender, EventArgs e)       //Farbe zum Malen ausgewählt
        {
            System.Windows.Forms.Panel pnlPressed = (System.Windows.Forms.Panel)sender;
            selectedColorPanel = pnlPressed;
            //if (colorDialog1.ShowDialog() == DialogResult.OK)       //Im Color-Dialog wir die Farbe ausgewählt
            //{
            //    selectedColorPanel.BackColor = colorDialog1.Color;
            //    //bt_color2.BackColor = colorDialog1.
            //    backColorButtons = colorDialog1.Color;
            //}
        }

        private void Clear_Click(object sender, EventArgs e)        //Das Panel wird zurück gesetzt und alle Pixel werden Weiß 
        {
            foreach (var item in pixel)
            {
                item.Color = Color.White;
            }
            this.Refresh();
        }

        private void bt_Speichern_Click(object sender, EventArgs e)     //Das Panel wird gespeichert
        {
            if (cb_SelectedPanal.Text != "")        //Es muss ein Panel ausgewählt sein
            {
                List<int> colors = new List<int>();     //Eine Pufferliste wird erstellt in die alle Farb-Werte gespeichert werden

                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < length; i++)
                    {
                        colors.Add(pixel[i, j].Color.ToArgb());
                    }
                }
                mw.savedPanels[cb_SelectedPanal.SelectedIndex].colors = colors;     //Die Liste color wird in dem entsprechenden Panel, das mit dem Index in der ComboBox übereinstimmt gespeichert(Beim reloaden der ComboBox wird jedes mal auf die Reihenfolge der Panels geachtet)
                mw.savedPanels[cb_SelectedPanal.SelectedIndex].showtime = Convert.ToDouble(tb_showtime.Text);       //Die angegebene Anzeigezeit für das Panel wird gespeichert
                mw.uploadPanels();          //Die Panels und Animationen werden hochgeladen
                MessageBox.Show("Speichern erfolgreich!");      //Der User erhält eine Messages das alles erfolgreich gespeichert wurde
            }
        }

        private void Fill_Click(object sender, EventArgs e)     //Methode für den Fill-Modus
        {
            if (fill)       //ändert die Farbe das der Benutzer sieht, dass er den Fill-Modus aktiviert hat
            {
                bt_fill.BackColor = SystemColors.Control;
            }
            else
            {
                bt_fill.BackColor = Color.LightGray;
            }
            fill = !fill;       //beim drücken auf den Knopf wird die aktivität des Modus geändert
        }

        public void fillButtons(Color original, int x, int y)       //Die rekursive Funktion für die Ausfüllung der Fläche verwendet
        {
            if (x < length && x >= 0 && y < height && y >= 0 && pixel[x, y].Color == original)
            {
                if (pixel[x, y].Color == backColorButtons)
                    return;
                pixel[x, y].Color = backColorButtons;       //Die Farbe des aktuelle betrachteten Pixels wird geändert
                fillButtons(original, x, y + 1);        //nach oben
                fillButtons(original, x + 1, y);        //nach rechts
                fillButtons(original, x, y - 1);        //nach unten
                fillButtons(original, x - 1, y);        //nach links    
            }
        }

        private void bt_NewPanel_Click(object sender, EventArgs e)      //Ein neues Panel wird erstellt
        {
            List<string> nameOfPanels = new List<string>();
            foreach (Panel p in mw.savedPanels)     //Eine Liste mit bis jetzt allen exsistierenden Panel und Animations Namen wird erstellt
            {
                nameOfPanels.Add(p.name);
            }
            foreach (Animation a in mw.savedAnimations)
            {
                nameOfPanels.Add(a.name);
            }
            if (tb_NamePanel.Text != "" && tb_NamePanel.Text.Any(char.IsDigit) == false && nameOfPanels.Contains(tb_NamePanel.Text) == false)        //Ein neues Panel wird nur erstellt, wenn sie nicht leer ist, keine Zahl beinhaltet und einen schon exsistierenden Namen beinhalten
            {
                string name = tb_NamePanel.Text;
                Panel newP = new Panel(name);       //neues PAnel mit dem eingegebenen Namen wird erstellt
                mw.savedPanels.Add(newP);
                cb_SelectedPanal.Items.Add(newP.name);
                tb_NamePanel.Text = "";
            }
            else if (tb_NamePanel.Text.Trim() == "")        //Hier werden ein paar Rückmeldungen an den User gegeben, warum das speichern nicht funktioniert hat
            {
                MessageBox.Show("Bitte einen Namen in das Textfeld eingeben!");
            }
            else if (tb_NamePanel.Text.Any(char.IsDigit) == true)
            {
                MessageBox.Show("Ziffern im Namen des Panels sind nicht erlaubt!");
            }
            else if (nameOfPanels.Contains(tb_NamePanel.Text) == true)
            {
                MessageBox.Show("Name des Panels ist bereits vergeben!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)     //Das ausgewählte Panel in der ComboBox wird ausgewählt und geladen
        {
            loadPanel(mw.savedPanels[cb_SelectedPanal.SelectedIndex]);
        }

        private void tb_NamePanel_Enter(object sender, EventArgs e)     //Ein Foreshadowing Text der dem User zeigt, was er hier eingeben soll
        {
            //if (tb_NamePanel.Text == "")          //Ich musste das hier auskommentieren, da wenn man den namen eingegeben hat und man auf den neu Button drücken wollte, der Text ja wieder zurück gesetzt wurde eher kritisch
            //{
            //    tb_NamePanel.Text = "Name";
            //}
            //else
            //{
            //    tb_NamePanel.Text = "";
            //}
        }

        private void tb_showtime_Enter(object sender, EventArgs e)      //Ein Foreshadowing Text der dem User zeigt, was er hier eingeben soll
        {
            //if (tb_showtime.Text == "")
            //{
            //    tb_showtime.Text = "Anzeigedauer";
            //}
            //else
            //{
            //    tb_showtime.Text = "";
            //}
        }

        private void bt_Löschen_Click(object sender, EventArgs e)       //Löschen
        {
            mw.savedPanels.Remove(mw.savedPanels[cb_SelectedPanal.SelectedIndex]);      //Das ausgewählt Panel wird aus der savedPanel Liste gelöscht
            reloadComboBox();       //Der Inahlt der ComboBox wird auf die neue savedPanel Liste angepast
        }

        private void bt_picture_Click(object sender, EventArgs e)
        {
            Panel p;
            List<int> puffer = new List<int>();
            
            Bitmap b;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                b = new Bitmap(open.FileName);
                if (b.Width != 24 || b.Height != 8)
                {
                    MessageBox.Show("Bitte füge ein Bild hinzu das eine maximale Breite von 24 und Höhe 8 Pixeln hat.");
                }
                else
                {
                    for (int i = 0; i < height; i++)
                    {
                        for (int m = 0; m < length; m++)
                        {
                            puffer.Add(b.GetPixel(m,i).ToArgb());
                        }
                    }
                    Name n = new Name(mw,puffer);
                    n.Show();

                   
                    
                }
            }
            name = "";
        }

        public void ImportPanel(Panel p)
        {
            mw.savedPanels.Add(p);
            mw.uploadPanels();
            reloadComboBox();
            cb_SelectedPanal.Text = "example";
        }

        private void p_Color_Select(object sender, EventArgs e)
        {
            System.Windows.Forms.Panel pnlPressed = (System.Windows.Forms.Panel)sender;
            selectedColorPanel = pnlPressed;
        }

        private void p_Color1_Click(object sender, EventArgs e)
        {

        }

        private void p_Color1_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)       //Im Color-Dialog wir die Farbe ausgewählt
            {
                selectedColorPanel.BackColor = colorDialog1.Color;
                //bt_color2.BackColor = colorDialog1.
                backColorButtons = colorDialog1.Color;
            }
        }

        private void p_Color1_Enter(object sender, EventArgs e)
        {

        }
    }
}
