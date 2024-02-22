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
    public partial class Form4 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter dataAdapter;
        DataTable dataTable;
        public Form4()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb";

            connection = new OleDbConnection(connectionString);
            InitializeComponent();
        }
        OleDbConnection Aconnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb");
        private void Form4_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        private void RefreshDataGridView()
        {

            Aconnection.Open();
                string query = "SELECT * FROM aracdetay";


                dataTable = new DataTable();
                dataAdapter = new OleDbDataAdapter(query, connection);


                dataAdapter.Fill(dataTable);


                dataGridView1.DataSource = dataTable;
            Aconnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["arac_plaka"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string iş_durumu = "dolu";
            string güncel_is_hali = "devam";
            connection.Open();
            string sqlText = "INSERT INTO nakliyedetay (plaka,gid_yer,mesafe,malzeme,agırlık,güncel_is_hali) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "', '"+güncel_is_hali+"')";
            OleDbCommand AccessCommand = new OleDbCommand(sqlText, connection);
            string updateQuery = "UPDATE aracdetay SET iş_durumu = '"+iş_durumu+ "' WHERE arac_plaka = '"+textBox1.Text+"'";
            OleDbCommand command = new OleDbCommand(updateQuery, connection);
            AccessCommand.ExecuteNonQuery();
            command.ExecuteNonQuery();
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
