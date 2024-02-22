using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace projeee
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Eren Süer\\source\\repos\\projeee\\login1.accdb";

            
            string query = "SELECT COUNT(*) AS Toplam, " +
                           "SUM(IIF(iş_durumu = 'Dolu', 1, 0)) AS DoluSayisi, " +
                           "SUM(IIF(iş_durumu = 'Boş', 1, 0)) AS BosSayisi " +
                           "FROM aracdetay";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            int toplamSayi = Convert.ToInt32(reader["Toplam"]);
                            int doluSayisi = Convert.ToInt32(reader["DoluSayisi"]);
                            int bosSayisi = Convert.ToInt32(reader["BosSayisi"]);

                            
                            chart1.Series.Add("IsDurumu");

                            
                            chart1.Series["IsDurumu"].Points.AddXY("Dolu", doluSayisi);
                            chart1.Series["IsDurumu"].Points.AddXY("Boş", bosSayisi);

                            
                            chart1.Series["IsDurumu"].ChartType = SeriesChartType.Pie;
                            chart1.ChartAreas[0].AxisX.Title = "İş Durumu Oranı";
                            chart1.ChartAreas[0].AxisY.Title = "Toplam Sayı: " + toplamSayi;
                            chart1.ChartAreas[0].AxisX.Interval = 1;
                        }
                    }
                }
            }
        }

    }
}
