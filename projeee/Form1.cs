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
using System.Xml;

namespace projeee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection Aconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            

            Aconnection.Open();
            OleDbDataReader dr;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Aconnection;
            cmd.CommandText = "SELECT * FROM  login WHERE isim= '" + textBox1.Text + "' AND parola= '" + textBox2.Text + "'";

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                isata mainform = new isata();
                mainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış");
            }
            Aconnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
