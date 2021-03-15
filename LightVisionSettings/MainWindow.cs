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
using System.Xml.Serialization;
using System.IO;



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

        //speichern der Vorlagen
        static XmlSerializer serializer;
        static FileStream stream;

        //Alle UserControl Panels
        public Dashboard dashboard;
        public Kacheln kacheln;
        public Settings settings;
        public Vorlagen vorlagen;
        public Animator animator;


        //Werte und dlls für das Bewegen einer borderlosen Form und Abrundung von Regions
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]     //DLL für die Abrundung der Ecken und Erstellung von Regions
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

            savedAnimations = new List<Animation>();        //Die Animationsliste wird initiakisiert
            savedPanels = downloadPanels();     //Die Panels werden heruntergeladen
            extractPanelsAnimations();          //Die heruntergeladen Panels werden in Animationen und Panels aufgeteilt

            dashboard = new Dashboard(this);        //Die UserControl Panels werden initialisiert
            p_Content.Controls.Add(dashboard);      //Das  Panel wird zum Content Panel hinzugefügt

            kacheln = new Kacheln(this);
            p_Content.Controls.Add(kacheln);
            kacheln.BringToFront();                 //Das Startpanel der Editor wird in den Vordergrund gebracht

            settings = new Settings(this);
            p_Content.Controls.Add(settings);

            vorlagen = new Vorlagen(this);
            p_Content.Controls.Add(vorlagen);

            animator = new Animator(this,25,8,24);
            p_Content.Controls.Add(animator);

            buttons = new List<Button>() {bt_Editor, bt_Animator, bt_Templates, bt_Dashboard, bt_Settings };        //Eine Liste mit allen Nav-Buttons wird erstellt, um diese Leichter zu handhaben

            timer1.Start();     //Der Einstellungstimer wird gestartet

            design();       //Das Design wird bearbeitet
        }

        public void extractPanelsAnimations()       //Hier wird beim Herunterladen von Panel und Animation unterschieden
                                                    //Panels können keine Digits im Namen haben
                                                    //Animationen bestehen aus Panels, die den Animationsnamen + eine  Zahl mit der entsprechenden Stelle in der Animation
        {
            List<Panel> copySavedPanels = new List<Panel>(savedPanels);      //Die heruntergeladenen Panels werden als Copy gespeichert
            List<Panel> puffer = new List<Panel>();     //Liste für die Panels einer Animation
            List<Animation> animations = new List<Animation>();     //Liste für die erstellten Animationen

            for (int j = 0; j < copySavedPanels.Count; j++)     
            {
                for (int i = 0; i < copySavedPanels.Count; i++)     //Es wird nach Animationen gesucht und nach dem Ende einer Animation wird die Schleife verlassen
                {
                    if (savedPanels[i].name.Any(char.IsDigit))      //Falls der Name eines Panels eine Zahl enthält
                    {
                        puffer.Add(savedPanels[i]);     //Das Panel wird zum Puffer hinzugefügt
                        string nameWODigits = ExtensionMethods.RemoveDigits(puffer[0].name);        //Die RemoveDigits Methode in der Extension Klasse entfernt die Zahl
                        if (i == copySavedPanels.Count && savedPanels[i + 1].name.StartsWith(nameWODigits))     //Es wird geschaut, dass die zuerst in keine OutOfIndex Exception gelaufen wird und dann geschaut, ob das nächste Panel zu der Animation dazu gehört
                        {
                            puffer.Clear();     //Der Puffer wird geleert
                            break;              //Die Schleife wird verlassen
                        }
                    }
                }
                if (puffer.Count >= 2)      //Falls die Schleife länger als 2 ist
                {
                    Animation a = new Animation(ExtensionMethods.RemoveDigits(puffer[0].name), puffer.Count, puffer[0].showtime, puffer);       //Eine neue Animation wird erstellt
                    savedAnimations.Add(a);     //Die Animation wird zur Liste hinzugefügt
                    foreach (Panel p in puffer)     //Alle Panels die jetzt in der Animation sind werden aus der Copy entfernt
                    {
                        copySavedPanels.Remove(p);
                    }
                    puffer.Clear();     //Der Puffe wird geleert
                }
            }
            savedPanels = copySavedPanels;      //Die übrigen Panels werden dann in der savedPanls Liste gespeichert
        }

        private void design()       // Alle Befehle, die beim start der Form ausgeführt werden und hauptsächlich kosmetischer Art sind.
        {
            settings.contentColor = contentColor;
            settings.menuColor = menuColor;
            bt_Editor.BackColor = menuColor;        //Die Startseite wird als Editor gestzt und die Farbe des Buttons wird angepasst

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));       //Die Form wird durch eine DLL abgerundet und bekommt eine neue Region

            bt_Editor.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));     //Die Button Region von allen Nav-Buttons wird mit einem DLL angepasst, dass diese abgerundet sind
            bt_Templates.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Settings.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Dashboard.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
            bt_Animator.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(buttonOffsetLeft, 0, bt_Editor.Width + 20, bt_Editor.Height, buttonRadius, buttonRadius));
        }

        public void uploadPanels()      //Die Panels werden als Liste an den Client gegeben und an den Server geschickt
        {
            Client client = new Client("135.181.35.212", 65432);
            client.SendPanel(savedPanels);
        }

        public List<Panel> downloadPanels()     //Die Panels werden vom dem Sever in Helsinki heruntergeladen und als Liste vom Client zurückgegeben
        {
            Client client = new Client("135.181.35.212", 65432);
            return client.GetPanel();
        }

        private void bt_Close_Click(object sender, EventArgs e)     //Schließen des Programms
        {
            if (dashboard.kacheln != null)          //Wenn die Liste der Kacheln nicht null ist
            {
                foreach (SmallKachel small in dashboard.kacheln)        //Es werden alle Kacheln durchgegangen und geschaut, ob es sich bei diesen um Animationen handelt. Dann wird der Thread in den Animationen geschlossen
                {
                    if (small.thisISAnAnimation)
                    {
                        small.thread.Abort();
                    }
                }
            }
            Environment.Exit(Environment.ExitCode);     //Das Programm wird geschlossen
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
            dashboard.DashboardPanels();        //Die Dashboard Panels werden alle neu geladen
        }

        private void bt_Settings_Click(object sender, EventArgs e)
        {
            settings.BringToFront();
            ButtonColorClick(sender);
        }
        private void bt_Animator_Click(object sender, EventArgs e)      //Nav Button für den Animator
        {
            animator.BringToFront();        //das ausgewählte User Control Panel wird nach Vorne gebracht
            ButtonColorClick(sender);       //die Methode für die Anpassung der Farbe der Nav Buttons wird augerufen
            animator.reloadComboBox();      //die Items der ComboBox werden neu erstellt
            animator.AddButton();       //Das Panel mit den 192 Pixel wird erstellt
            animator.AddCircles();      //Die Kreise für das Auswählen des aktuellen Panels in der Animation werden erstellt
            animator.Refresh();         //Die Graphics des UserControll wird neu geladen, wodurch die Kreis und Pixel Objekte gemalt werden 
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)   //Methode zum bewegen der RandlosenForm ist(ist auf einzelne Panels angewand, die keinen Contant besitzen)
        {
            if (e.Button == MouseButtons.Left)      //Falls die Linke Mouse taste gedrückt ist
            {
                ReleaseCapture();       //wird eine DLL geöffnet die das Bewegen handelt
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ButtonColorClick(object sender)        //Damit einer der Nav-Buttons gedrückt wird, wird die Farbe angeglichen und die Aktivität geändert
        {
            Button b = (Button)sender;
            foreach (var item in buttons)       //alle Buttons außer der Button(sender), bekommen alle Buttons einen transparenten Hintergrund
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

        private void timer1_Tick(object sender, EventArgs e)        //Der timer überprüft immer wieder die Einstellungen und gleicht das Aussehen daran an
        {
            if (settings.rgb)       //Falls das RGB-Setting aktiviert ist soll die Programmname in Bunten Farben aufleuchten
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

            ChangeColor();      //Die Farbeinstellungen werden immer wieder an die Einstellungen angeglichen
        }

        private void ChangeColor()      //falls sich die Farbe in den Einstellungen ändert die Methode alle Farben an die neue Auswahl anpasst
        {
            menuColor = settings.menuColor;
            contentColor = settings.contentColor;

            settings.BackColor = menuColor;
            dashboard.BackColor = menuColor;
            kacheln.BackColor = menuColor;
            p_Content.BackColor = menuColor;
            vorlagen.BackColor = menuColor;
            animator.BackColor = menuColor;
            foreach (var item in buttons)       //Hier wird der aktive NavButton gesucht und dessen Farbe umgestellt
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

        public void SerilizeObjekt(Animation animation)     //Serializiert eine Animationsvorlage 
        {
            serializer = new XmlSerializer(typeof(Animation));      //erstellt eine Serilizer für die Klasse Animation
            stream = new FileStream("..\\Resources\templates\templatesAnimation.xml", FileMode.Open);       //erstellt einen Stream der die entsprechende Datei entweder öffnet oder neu erstellt
            serializer.Serialize(stream, animation);        //serializiert die Datei
            stream.Close();     //schließt den Stream
        }

        public void SerilizeObjekt(Panel panel)     //Serialisiert eine Panelvorlage
        {
            serializer = new XmlSerializer(typeof(Panel));
            stream = new FileStream("..\\Resources\templates\templatesPanel.xml", FileMode.Open);
            serializer.Serialize(stream, panel);
            stream.Close();
        }

        public Panel DeSerilizeObjekt(Panel panel)      //Deserialisiert ein Panel
        {
            stream = new FileStream("..\\Resources\templates\templatesPanel.xml", FileMode.Open);       //erstellt einen Stream für die entsprechende Datei
            return (Panel)serializer.Deserialize(stream);       //gibt dass ensprechende Panel wieder zurück
        }

        public Animation DeSerilizeObjekt(Animation a)      //Deserialisiert eine Animation
        {
            stream = new FileStream("..\\Resources\templates\templatesAnimation.xml", FileMode.Open);
            return (Animation)serializer.Deserialize(stream);
        }
    }
}
