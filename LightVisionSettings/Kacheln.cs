using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
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

        Color backColorButtons = Color.Transparent;

        private void AddButtons()
        {
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < 28; i++)
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
            clickedButton.BackColor = backColorButtons;
        }

        private void bt_Speichern_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            //connectionString = @"Data Source=localhost;Initial Catalog=lightvision;User ID=root;Password=";
            connectionString = @"Data Source=localhost;Initial Catalog=lightvision;User ID=root";
            cnn = new SqlConnection(connectionString);

            List<string> listOfColors = new List<string>();
            foreach(Control c in Controls)
            {
                if(c is Button && c.Name.Substring(0,3) is "led")
                {
                    listOfColors.Add($"{c.BackColor.A}, {c.BackColor.R}, {c.BackColor.G}, {c.BackColor.B}");
                }
            }

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            cnn.Open();
            foreach (string s in listOfColors)
            {
                sql = "INSERT INTO kacheln VALUES (s)";
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
            }
            cnn.Close();
        }

        private void bt_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bt_Color.BackColor = colorDialog1.Color;
                backColorButtons = colorDialog1.Color;
            }
        }
    }
}
