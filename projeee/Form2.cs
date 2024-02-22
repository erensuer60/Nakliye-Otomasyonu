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
    public partial class Form2 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter dataAdapter;
        DataTable dataTable;
        
        public Form2()
        {
            InitializeComponent();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb";
            
            connection = new OleDbConnection(connectionString);
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
           
        }
        private void RefreshDataGridView()
        {
            string query = "SELECT * FROM nakliyedetay";


            dataTable = new DataTable();
            dataAdapter = new OleDbDataAdapter(query, connection);


            dataAdapter.Fill(dataTable);


            dataGridView1.DataSource = dataTable;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["gid_yer"].Value.ToString();
            textBox2.Text = row.Cells["mesafe"].Value.ToString();
            textBox3.Text = row.Cells["malzeme"].Value.ToString();
            textBox4.Text = row.Cells["agırlık"].Value.ToString();
            textBox8.Text = row.Cells["plaka"].Value.ToString();





        }

        private void Güncelle_Click(object sender, EventArgs e)
        {
            connection.Open();

            string updateQueryNakliye = "UPDATE nakliyedetay SET gid_yer = @gid_yer, mesafe = @mesafe, malzeme = @malzeme, agırlık = @agırlık, güncel_is_hali = @güncel_is_hali WHERE plaka = @plaka";
            OleDbCommand command = new OleDbCommand(updateQueryNakliye, connection);
            command.Parameters.AddWithValue("@gid_yer", textBox1.Text);
            command.Parameters.AddWithValue("@mesafe", textBox2.Text);
            command.Parameters.AddWithValue("@malzeme", textBox3.Text);
            command.Parameters.AddWithValue("@agırlık", textBox4.Text);
            command.Parameters.AddWithValue("@güncel_is_hali", comboBox1.Text);
            command.Parameters.AddWithValue("@plaka", textBox8.Text);
            command.ExecuteNonQuery();

            string iş_durumu = "boş";
            string updateQueryArac = "UPDATE aracdetay SET iş_durumu = @is_durumu WHERE arac_plaka = @arac_plaka";
            OleDbCommand updateCommand = new OleDbCommand(updateQueryArac, connection);
            updateCommand.Parameters.AddWithValue("@is_durumu", iş_durumu);
            updateCommand.Parameters.AddWithValue("@arac_plaka", textBox8.Text); 
            updateCommand.ExecuteNonQuery();

            RefreshDataGridView();
            connection.Close();

        }

        private void Sil_Click(object sender, EventArgs e)
        {
            connection.Open();

            
            string deleteQuery = "DELETE FROM nakliyedetay WHERE plaka = @plaka";
            OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection);
            deleteCommand.Parameters.AddWithValue("@plaka", textBox8.Text);
            deleteCommand.ExecuteNonQuery();

            
            string iş_durumu = "boş";
            string updateQueryArac = "UPDATE aracdetay SET iş_durumu = @is_durumu WHERE arac_plaka = @arac_plaka";
            OleDbCommand updateCommand = new OleDbCommand(updateQueryArac, connection);
            updateCommand.Parameters.AddWithValue("@is_durumu", iş_durumu);
            updateCommand.Parameters.AddWithValue("@arac_plaka", textBox8.Text); 
            updateCommand.ExecuteNonQuery();

            RefreshDataGridView();
            connection.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            isata mainform = new isata();
            mainform.Show();
            this.Hide();
        }
    }
}
