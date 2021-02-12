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
        public Kacheln()
        {
            InitializeComponent();
            AddButtons();
        }

        private void AddButtons()
        {
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i <= 28; i++)
                {
                    Button button = new Button();
                    button.Name = $"led{i}_{k}";
                    button.Location = new Point(10 + 25 * i, 10 + 25 * k);
                    button.Size = new Size(25, 25);
                    button.BackColor = Color.White;
                    button.Click += new EventHandler(buttonLED_Click);

                    // Adding this button to form 
                    this.Controls.Add(button);
                }
            } 
        }

        private void buttonLED_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                clickedButton.BackColor = colorDialog1.Color;
            }
        }

        private void bt_Speichern_Click(object sender, EventArgs e)
        {

        }
    }
}
