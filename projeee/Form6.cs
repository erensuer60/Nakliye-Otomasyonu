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
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace projeee
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb";

           
            string query = "SELECT arac_marka, COUNT(*) AS TırSayısı FROM aracdetay GROUP BY arac_marka";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        
                        chart1.Series.Add("TırSayısı");

                        while (reader.Read())
                        {
                            
                            string tırMarka = reader["arac_marka"].ToString();
                            int tırSayısı = Convert.ToInt32(reader["TırSayısı"]);

                            
                            chart1.Series["TırSayısı"].Points.AddXY(tırMarka, tırSayısı);

                            
                            chart1.Series["TırSayısı"].Points.Last().Color = Color.Turquoise;
                        }
                    }
                }
            }

            
            chart1.Series["TırSayısı"].ChartType = SeriesChartType.Column; 
            chart1.ChartAreas[0].AxisX.Title = "Tır Markaları";
            chart1.ChartAreas[0].AxisY.Title = "Tır Sayısı";
            chart1.ChartAreas[0].AxisX.Interval = 1; 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            isata mainform = new isata();
            mainform.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
