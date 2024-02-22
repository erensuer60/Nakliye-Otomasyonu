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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection Aconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb");

        private void Ekle_Click(object sender, EventArgs e)
        {
            string iş_durumu = "boş";
            Aconnection.Open();
            string sqlText = "INSERT INTO aracdetay (arac_sahibi,arac_marka,arac_plaka,max_yük,iş_durumu) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+iş_durumu+"')";
            OleDbCommand AccessCommand = new OleDbCommand(sqlText, Aconnection);
            int rowsAffected = AccessCommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Veri başarıyla eklendi!");
            }
            else
            {
                MessageBox.Show("Veri eklenirken bir hata oluştu.");
            }

            Aconnection.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            isata mainform = new isata();
            mainform.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
