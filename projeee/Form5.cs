using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace projeee
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection Aconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb");

        private void Form5_Load(object sender, EventArgs e)
        {
            Aconnection.Open();

            string query = "SELECT arac_plaka, iş_durumu FROM aracdetay";
            OleDbCommand command = new OleDbCommand(query, Aconnection);
            OleDbDataReader reader = command.ExecuteReader();

            int buttonCount = 0;
            while (reader.Read())
            {
                string plateNumber = reader["arac_plaka"].ToString();
                string isDurumu = reader["iş_durumu"].ToString();
                Button plateButton = new Button();

                plateButton.Text = plateNumber;
                plateButton.Name = "btnPlate" + buttonCount.ToString();
                plateButton.Click += new EventHandler(Button_Click);

                if (isDurumu == "dolu")
                {
                    plateButton.BackColor = Color.Red;
                }
                else if (isDurumu == "boş")
                {
                    plateButton.BackColor = Color.Green;
                }
                
                plateButton.Size = new Size(100, 40);
                flowLayoutPanel1.Controls.Add(plateButton);

                buttonCount++;
            }

            Aconnection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isata mainform = new isata();
            mainform.Show();
            this.Hide();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            MessageBox.Show("Seçilen plaka: " + clickedButton.Text);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
