using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Database_Party_Election_And_Graphics_Program
{
    public partial class FrmGraphics : Form
    {
        public FrmGraphics()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=TAMER\SQLEXPRESS;Initial Catalog=DbElectionProject;Integrated Security=True");
        private void FrmGraphics_Load(object sender, EventArgs e)
        {
            //İlçe Adlarını ComboBox a çekme
            connection.Open();
            SqlCommand command = new SqlCommand("select DISTRICTNAME from TBLDISTRICT", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader[0]);
            }
            connection.Close();

            //Grafiğe toplam sonuçları getirme
            connection.Open();
            SqlCommand command1 = new SqlCommand("Select SUM(APARTY),SUM(BPARTY),SUM(CPARTY),SUM(DPARTY),SUM(EPARTY) FROM TBLDISTRICT", connection);
            SqlDataReader dataReader1 = command1.ExecuteReader();
            while (dataReader1.Read()) 
            {
                chart1.Series["Parties"].Points.AddXY("PARTY A", dataReader1[0]);
                chart1.Series["Parties"].Points.AddXY("PARTY B", dataReader1[1]);
                chart1.Series["Parties"].Points.AddXY("PARTY C", dataReader1[2]);
                chart1.Series["Parties"].Points.AddXY("PARTY D", dataReader1[3]);
                chart1.Series["Parties"].Points.AddXY("PARTY E", dataReader1[4]);
            }
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM TBLDISTRICT WHERE DISTRICTNAME =@P1", connection);
            command.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                progressBar1.Value = int.Parse(dataReader[2].ToString());
                progressBar2.Value = int.Parse(dataReader[3].ToString());
                progressBar3.Value = int.Parse(dataReader[4].ToString());
                progressBar4.Value = int.Parse(dataReader[5].ToString());
                progressBar5.Value = int.Parse(dataReader[6].ToString());

                LblA.Text = dataReader[2].ToString();
                LblB.Text = dataReader[3].ToString();
                LblC.Text = dataReader[4].ToString();
                LblD.Text = dataReader[5].ToString();
                LblE.Text = dataReader[6].ToString();
            }
            connection.Close();
        }
    }
}
