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
using System.Drawing.Imaging;

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
        private System.Windows.Forms.Panel selectedColorPanel;  //Der ausgewählte Button der Color-Palette
        private bool fill;                  //ob der Fill-Tool Modus aktiviert ist
        private Color clickedButton;        //die Farbe die in dem Bereich ist, um den Bereich zu füllen
        public int selectedPanel = 0;
        public ComboBox comboBoxText;
        public bool colorPicker = false;

        public int numberOfPanels = 5;


        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);

        public static Color GetColorAt(int x, int y)        //Methode, die mit einem DLL zuverlässlich die Farbe jedes Pixels auf dem Display abrufen kann
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }


        public Animator(LightVision_Base mw, int size, int height, int length)  //Konstruktor mit Pixelgröße und Anzahl in x und y Richtung
        {
            InitializeComponent();
            
            this.mw = mw;
            this.size = size;
            this.height = height;
            this.length = length;
            this.Size = new Size(747, 458);

            comboBoxText = cb_SelectedPanal;
            tb_showtime.Text = ""+5;
            selectedColorPanel = p_Color1;

            Random r = new Random();
            colorDialog1.Color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));     //Eine zufällige Farbe am Anfang für einen spaßigen Start ;)
            p_Color1.BackColor = colorDialog1.Color;
            backColorButtons = colorDialog1.Color;

        }

        public void reloadComboBox()        //Die comboBox für die ausgewählten Animation wird neu geladen
        {
            cb_SelectedPanal.Items.Clear();
            foreach (Animation a in mw.savedAnimations)
            {
                cb_SelectedPanal.Items.Add(a.name);
            }
        }

        public void OnDeactivate(object sender, EventArgs e)        //Falls neben die Form geklickt wird, wird diese Methode aufgrufen, die alle Werte auf die ausgewählte Farbe setzt
        {
            if (colorPicker)
            {
                Point pointWindow = MousePosition;
                selectedColorPanel.BackColor = GetColorAt(pointWindow.X, pointWindow.Y);
                backColorButtons = GetColorAt(pointWindow.X, pointWindow.Y);
                colorDialog1.Color = GetColorAt(pointWindow.X, pointWindow.Y);
            }
        }

        private void bt_ColorPicker_Click(object sender, EventArgs e)       //Die Farbe des ColorPickerButtons wird immer geändert und die aktivität auch
        {
            if (!fill)
            {
                if (colorPicker)
                {
                    bt_ColorPicker.BackColor = mw.menuColor;
                }
                else
                {
                    bt_ColorPicker.BackColor = mw.contentColor;
                }
                colorPicker = !colorPicker;
            }
        }

        public void AddButton()     //Das Panel auf dem die User malen können wird erzeugt
        {
            pixel = new Pixel[length, height];
            int d = 0;
            for (int i = 0; i < height; i++)
            {
                for (int m = 0; m < length; m++)
                {
                    pixel[m, i] = new Pixel(m * size + ((747-24*30)/2)-10, i * size + 30, size);

                }
            }
            this.DoubleBuffered = true;             //damit die refresh rate höher ist
            this.MouseMove += kachel_MouseMove;     //da man nicht hover und mousedown gleichzeitig als event verwenden kann mussten wir überprüfen, ob sich die Maus bewegt und über einem der Rechtecken befindet
            this.fill = false;                      //fill-Modus deaktiviert

            this.Refresh();
        }

        public void AddCircles()        //Die Kreise werden neu gemalt
        {
            circles = new CircleAnimator[numberOfPanels];
            for (int i = 0; i < numberOfPanels; i++)
            {
                circles[i] = new CircleAnimator(10, Color.White, i * ((24 * 30 - 20) / numberOfPanels) - 10 + ((747 - 24 * 30) / 2) + ((24 * 30 - 20) / numberOfPanels) / 2 + 20, 20);

            }
        }

        private void loadPanel(Panel selectedPanel)     //Anzeigen eines Panels von einer Animation
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
            if (pixel != null && circles != null)
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
        }

        protected override void OnMouseDown(MouseEventArgs e)       //Wird aufgerufen, wenn die Linke Maus gedrückt wird
        {
            if (cb_SelectedPanal.Text != "")
            {
                int counter = 0;
                foreach (CircleAnimator c in circles)       //es werden alle Kreise der UI durchgegangen, ob einer gedrückt wurde
                {
                    if (e.X + 10 >= c.X && e.X < c.X + c.Radius && e.Y + 10 >= c.Y && e.Y < c.Y + c.Radius)
                    {

                        selectedPanel = counter;
                        c.Color = mw.contentColor;
                        label1.Text = "" + counter;
                        tb_showtime.Text = "" + mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel].showtime;
                        loadPanel(mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel]);
                        foreach (CircleAnimator ci in circles)
                        {
                            if (ci != c)
                            {
                                ci.Color = Color.White;
                            }
                        }
                        this.Refresh();
                        return;
                    }
                    counter++;
                }


                base.OnMouseDown(e);
                int x = (e.X -7)/ 30;                                      //Die x und y Koordinaten werden durch 30 geteilt, damit wir die Pixel Koordianten in Array-Positionen umrechnen können
                int y = (e.Y - 30) / 30;

                if (fill && x < length && x >= 0 && y < height && y >= 0)       //Die x und y Werte sollten nicht größer als 28/10 und kleiner als 0 sein, da e die Werte als 0 bis 10 ausgibt
                {
                    clickedButton = pixel[x, y].Color;                  //Die Farbe auf das geklickte Feld wird gespeichert, da man ja wissen muss welche Fläche, umgefärbt werden soll
                    fillButtons(clickedButton, x, y);                                  //Die Rekursive Funktion wird aufgerufen
                    this.Refresh();                                     //Die gemalten Rechtecke werden geudatet
                    savePanel();
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
                savePanel();

            }
            if (colorPicker)        //Wenn der Colorpicker ausgewählt ist
            {
                Point pointToWindow = MousePosition;

                Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                bmpScreenshot.Save("Screenshot.png", ImageFormat.Png);


                Color c = bmpScreenshot.GetPixel(pointToWindow.X, pointToWindow.Y);     //Die Frabe wird vom Screenshot abgerufen, an der entsprechenden Position, wo die Maus gedrückt wurde
                selectedColorPanel.BackColor = c;
                backColorButtons = c;
                colorDialog1.Color = c;
            }
        }

        private void savePanel()        //Das aktuelle Panel wird gespeichert also nur ein Panel der Animation
        {
            List<int> puffer = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 24; m++)
                {
                    puffer.Add(pixel[m,i].Color.ToArgb());
                }
            }

            if (cb_SelectedPanal.Text != "")        //Nur wenn auch eine Animation ausgewählt ist
            {
                mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel].colors = puffer;
                mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel].showtime = Convert.ToDouble(tb_showtime.Text);
                mw.savedAnimations[cb_SelectedPanal.SelectedIndex].wiederholungen = (int)nm_Wiederholungen.Value;
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
                savePanel();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)         //Wird aktiviert, wenn die Linke Maus Taste aufgehört wird zu drücken
        {
            base.OnMouseUp(e);
            onClick = false;                                        //der druckstatus der Maus wird geändert
        }

        private void Clear_Click(object sender, EventArgs e)        //Die Pixel werde alle auf Weiß gesetzt
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
                bt_fill.BackColor = mw.menuColor;
            }
            else
            {
                bt_fill.BackColor = mw.contentColor;
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

        private void bt_NewPanel_Click(object sender, EventArgs e)      //Ein neues Panel wird erstellt
        {
            List<string> nameOfPanels = new List<string>();     //Alle bisherigen Panelnamen werden rausgesucht, da diese verboten sind
            foreach (Panel p in mw.savedPanels)
            {
                nameOfPanels.Add(p.name);
            }
            foreach (Animation p in mw.savedAnimations)
            {
                nameOfPanels.Add(p.name);
            }
            nameOfPanels.Add("clock");
            nameOfPanels.Add("stonks");
            if (tb_NamePanel.Text.Trim() != "" && tb_NamePanel.Text.Any(char.IsDigit) == false && nameOfPanels.Contains(tb_NamePanel.Text) == false)
            {
                string name = tb_NamePanel.Text;
                Animation animation = new Animation(name,(int)number.Value, Convert.ToDouble(tb_showtime.Text));
                animation.numberOfPanels = (int)number.Value;
                numberOfPanels = (int)number.Value;
                mw.savedAnimations.Add(animation);
                cb_SelectedPanal.Items.Add(name);
                cb_SelectedPanal.Text = "";
                tb_NamePanel.Text = "";
                AddCircles();
                label1.Text = selectedPanel + "";
            }
            else if(tb_NamePanel.Text.Trim() == "")
            {
                MessageBox.Show("Bitte einen Namen in das Textfeld eingeben!");
            }
            else if(tb_NamePanel.Text.Any(char.IsDigit) == true)
            {
                MessageBox.Show("Ziffern im Namen des Panels sind nicht erlaubt!");
            }
            else if (nameOfPanels.Contains(tb_NamePanel.Text) == true)
            {
                MessageBox.Show("Name des Panels ist bereits vergeben!");
            }
        }

        private void cb_SelectedPanal_SelectedIndexChanged(object sender, EventArgs e)      //Wenn ein neues Panel ausgewählt wird, wird der Animator in seinen Urstand zurückversetzt
        {
            RealoadAnimator();
        }

        private void bt_Löschen_Click(object sender, EventArgs e)       //Die ausgewählte Animation wird gelöscht
        {
            selectedPanel = 0;
            AddButton();
            AddCircles();
            tb_NamePanel.Text = "";
            tb_showtime.Text = "";
            mw.savedAnimations.Remove(mw.savedAnimations[cb_SelectedPanal.SelectedIndex]);
            reloadComboBox();
        }

        public void RealoadAnimator()       //Wird benutzt, um den Animator beim Neuauswählen oder neu öffnen wieder in seinen Urzustand zu versetzen
        {
            selectedPanel = 0;
            numberOfPanels = mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation.Length;
            AddCircles();
            circles[0].Color = mw.contentColor;
            foreach (CircleAnimator circle in circles)
            {
                if (circles[0] != circle)
                {
                    circle.Color = Color.White;
                }
            }
            label1.Text = selectedPanel + "";
            nm_Wiederholungen.Value = mw.savedAnimations[cb_SelectedPanal.SelectedIndex].wiederholungen;
            loadPanel(mw.savedAnimations[cb_SelectedPanal.SelectedIndex].animation[selectedPanel]);
        }

        private void tb_showtime_MouseLeave(object sender, EventArgs e)     //Wenn die Showtime verändert wird wird gespeichert
        {
            savePanel();
        }

        private void bt_picture_Click(object sender, EventArgs e)       //Zum eigfügen von einzelnen Bildern oder Gifs(erkennt Bilder und Gifs automatich)
        {
            if (tb_showtime.Text == "" || tb_showtime.Text == "5")      
            {
                MessageBox.Show("Du kannst die Länge der einzelnen Gif-Bilder in der oberen rechten Ecke anpassen, bevor du das Bild auswählst");
            }
            else
            {
                Panel p;
                List<int> puffer = new List<int>();

                Bitmap b;
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)       
                {
                    b = new Bitmap(open.FileName);
                    if (open.FileName.EndsWith(".gif"))     //falls es sich um ein Gif handelt
                    {
                        List<Panel> panels = new List<Panel>();
                        foreach (Image image in GetFramesFromAnimatedGIF(b))
                        {
                            puffer = new List<int>();
                            Bitmap bitmap = (Bitmap)image;
                            if (bitmap.Width != 24 || bitmap.Height != 8)       //Größe wird angepasst
                            {
                                bitmap = new Bitmap(bitmap, new Size(24, 8));
                            }
                            for (int i = 0; i < height; i++)
                            {
                                for (int m = 0; m < length; m++)
                                {
                                    puffer.Add((bitmap.GetPixel(m, i).ToArgb()));
                                }
                            }
                            panels.Add(new Panel("", puffer, Convert.ToDouble(tb_showtime.Text)));      //Von jeder Gif dimenension wird eine Panel erzeugt und zu einer Litehinzugefügt
                        }
                        if (panels.Count <= 40)     //Maximal Gif mit 40 Dimensionen
                        {
                            Name n = new Name(mw, panels);
                            n.Show();
                        }
                        else
                        {
                            MessageBox.Show("Dein Gif hat zu viele Bilder");
                        }

                    }
                    else if (cb_SelectedPanal.Text != "")   
                    {
                        if (b.Width != 24 || b.Height != 8)     //Die Größe wird auf unser Verhältnis geändert
                        {
                            b = new Bitmap(b, new Size(24, 8));
                        }
                        for (int i = 0; i < height; i++)        //Alle Pixel werden neu gemalt
                        {
                            for (int m = 0; m < length; m++)
                            {
                                puffer.Add(b.GetPixel(m, i).ToArgb());
                            }
                        }
                        loadPanel(new Panel(mw.savedAnimations[cb_SelectedPanal.SelectedIndex].name + selectedPanel, puffer, 5));       //Das Bild wird auf auf das augewählte Panel übertragen 
                        savePanel();
                    }

                }
            }
        }

        public void ImportAnimation(Animation a)        //Methode, die von der Form Name aufgerufen wird, falls ein Gif importiert wird
        {
            mw.savedAnimations.Add(a);
            mw.uploadPanels();
            reloadComboBox();
        }

        public Image[] GetFramesFromAnimatedGIF(Image IMG)      //Methode zum extrahieren von einezelnen Bildern des Gifs
        {
            List<Image> IMGs = new List<Image>();
            int Length = IMG.GetFrameCount(FrameDimension.Time);        //Es wird gezählt, wie viele Dimensionen das Gif hat

            for (int i = 0; i < Length; i++)
            {
                IMG.SelectActiveFrame(FrameDimension.Time, i);
                IMGs.Add(new Bitmap(IMG));
            }

            return IMGs.ToArray();
        }

        private void paletteChangeColor(object sender, EventArgs e)       //Farbe zum Malen ausgewählt
        {
            System.Windows.Forms.Panel pnlPressed = (System.Windows.Forms.Panel)sender;
            selectedColorPanel = pnlPressed;
            backColorButtons = pnlPressed.BackColor;
            colorDialog1.Color = pnlPressed.BackColor;
        }

        private void p_Color1_DoubleClick(object sender, EventArgs e)       //Damit man beim Color Panel die Farbe im Color Dialog auswählen kann
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)       //Im Color-Dialog wir die Farbe ausgewählt
            {
                selectedColorPanel.BackColor = colorDialog1.Color;
                backColorButtons = colorDialog1.Color;
            }
        }

        private void nm_Wiederholungen_Leave(object sender, EventArgs e)        //Wenn die Wiederholungzeit geändert wird, wird die Animation gespeichert
        {
            savePanel();
        }
    }
}
