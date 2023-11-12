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
    public partial class FrmElection : Form
    {
        public FrmElection()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=TAMER\SQLEXPRESS;Initial Catalog=DbElectionProject;Integrated Security=True");

        private void BtnOyGiris_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TBLDISTRICT (DISTRICTNAME, APARTY,BPARTY,CPARTY,DPARTY,EPARTY) values (@P1,@P2,@P3,@P4,@P5,@P6)", connection);
            command.Parameters.AddWithValue("@P1", TxtDistrictName.Text);
            command.Parameters.AddWithValue("@P2", TxtA.Text);
            command.Parameters.AddWithValue("@P3", TxtB.Text);
            command.Parameters.AddWithValue("@P4", TxtC.Text);
            command.Parameters.AddWithValue("@P5", TxtD.Text);
            command.Parameters.AddWithValue("@P6", TxtE.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Oy Girişi Yapıldı");
        }

        private void BtnGraphics_Click(object sender, EventArgs e)
        {
            FrmGraphics frmGraphics = new FrmGraphics();
            frmGraphics.Show();
        }
    }
}
