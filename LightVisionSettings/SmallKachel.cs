using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightVisionSettings
{
    public partial class SmallKachel : UserControl
    {
        //Variablen für Beide Animation/Panel
        private LightVision_Base mw;
        public Pixel[,] pixel;      //Ein zweidimensionales Array mit allen aktuellen Pixeln
        public int size;        //Größe der Pixel
        public int height;      //Höhe der LED Matrix
        public int length;      //Breite der LED Matrix
        public Point mouseDown;     //Position an der die Maus das letzte mal auf dem Panel heruntergedrücklt wurde
        public bool moved = false;      //Wurde die Kachel schon bewegt
        public int matchingPanel;       //Das passende Panel/Animation in der Liste savedPanel/Animation

        //Variablen für die Animationen
        public int shownPanel = 0;      //das aktuell angezeigt Panel im Panel Array der Animation
        public Panel[] panels;      //Alle Panels die in der Animation gespeichert werden
        public Image[] images;      //Bilder Array in dem die Panels zu Bildern convertiert werden, um Resourcen effiezenter zu sein
        public PictureBox pb;       //Die PictureBox in der die Bilder angezeigt werden
        public bool animations = true;      //animationen sind generell auf eingeschaltet gesetzt
        public bool thisISAnAnimation = false;      //Der Wert der mir ganz klar sagt, ob es sich hierbei um eine Antimation handelt
        public Thread thread;       //Der Thread in dem die Animationen bzw. der Bilderwechsel ausgeführt wird

        public SmallKachel(int size, List<int> colors, int heigh, int lengt)        //konstruktor für einzelne Panels
        {
            InitializeComponent();
            height = heigh;
            length = lengt;
            this.size = size;
            pixel = new Pixel[length, height];
            int d = 0;
            for (int i = 0; i < height; i++)        //Das Panel wird einmal auf die Graphic des SmallKachel UserControl gemalt
            {
                for (int m = 0; m < length; m++)
                {
                    pixel[m, i] = new Pixel(m * size-10, i * size-10, size, Color.FromArgb(colors[d]));
                    d++;
                }
            }
            this.Refresh();
        }

        public SmallKachel(int size, Panel[] panels, int heigh, int lengt,LightVision_Base mw)      //Konstruktor für Aninmationen 
        {
            InitializeComponent();
            this.mw = mw;
            height = heigh;
            length = lengt;
            this.panels = panels;
            this.size = size;
            thisISAnAnimation = true;       //Der Wert, dass es sich hier um eine Animation handelt wird gesetzt
            animations = mw.settings.animationValue;        //Der Animationswert wird aus den Einstellungen abgerufen

            CreateBitmapes(panels);     //Die Bilder werden erstellt

            pb = new PictureBox();      //Die PictureBox wird intialisiert
            pb.Size = new Size(1000,1000);
            pb.Enabled = false;     //Die pB wird enabled, da man sonst nicht mehr die Events von dem UserControl benutzen kann
            this.Controls.Add(pb);      //Die Picturbox wird zur UserControl hinzugefügt

            thread = new Thread(Animation);     //thread wird initalisiert
            thread.Start();     //der Thread wird gestartet
        }

        public void Animation()     //gethreadedte Methode die dann zwischen den Bildern wechselt
        {
            while (thisISAnAnimation)       //Tue dies
            {
                if (animations)     //überprüfe, ob die Einstellung für Animationen an sind
                {
                    pb.Image = images[shownPanel];

                    System.Threading.Thread.Sleep((int)panels[shownPanel].showtime * 1000);     //warte so lange wie das Panel als showtime eingetragen hat
                    shownPanel++;       //Das aktuelle Panel wird um einz dazu addiert
                    if (shownPanel == panels.Length)        //Falls der Counter das ende des Arrays erreicht hat soll dieser Wert wieder auf 0 gesetzt werden
                    {
                        shownPanel = 0;
                    }
                }
                else       //Ansonstens zeige nur das erste Panel
                {
                    shownPanel = 0;
                    pb.Image = images[shownPanel];
                    System.Threading.Thread.Sleep((int)panels[shownPanel].showtime * 1000);     //Man braucht hier auch einen stop, da sonst das Programm diesen Prozzes so oft wiederholt und schnell wiederholt, dass das ganze Programm buget
                }
            }
        }

        private void CreateBitmapes(Panel[] panels)     //Erstellt eine Array von Images, indem die Panel Daten in Bitmapes convertiert werden und diese dann als Image gespeichert werden
        {
            images = new Image[panels.Length];
            for (int i = 0; i < panels.Length; i++)     //Dieser Prozzes wird für jedes Panel gemacht
            {
                Bitmap b = new Bitmap(24*10, 8*10);
                Graphics g = Graphics.FromImage(b);     //Es wird auf die Graphic Instanz des Bitmap herausgezogen
                int d = 0;
                for (int k = 0; k < 8; k++)
                {
                    for (int t = 0; t < 24; t++)
                    {

                        Render(g, t * 10, k * 10, 10, Color.FromArgb(panels[i].colors[d]));     //Es wird auf der Bitmap gemalt
                        d++;
                    }
                }
                Image image = b;     //Bitmap wird in als Image gespeichert
                images[i] = image;
                g.Dispose();
            }
        }

        public void Render(Graphics g,int x,int y,int size, Color color)        //Malt ein Rechtecke auf einer Graphic Instanz
        {
            g.FillRectangle(new SolidBrush(color), x , y , size, size);
        }

        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            if (!thisISAnAnimation)
            {
                base.OnPaint(e);
                foreach (Pixel p in this.pixel)     //Es werden alle Pixel durchgegangen und diese malen sich dann selber
                    p.Render(e.Graphics);
            }
        }
    }
}
