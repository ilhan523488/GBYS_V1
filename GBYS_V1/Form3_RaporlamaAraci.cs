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

namespace GBYS_V1
{
    public partial class Form3_RaporlamaAraci : DevExpress.XtraEditors.XtraForm
    {
        public Form3_RaporlamaAraci()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VADL0P2\SQLEXPRESS;Initial Catalog=GBYS_V1;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        DataSet ds;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textBox4.Text == "" || textBox33.Text == "")
            {
                //
            }
            else
            {
                string kayit = "update LABORATUVAR_ISLEMLERI set SONUC=@p1 where ISLEM_NO=@p3 AND TEST_ID=@p4";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@p1", richEditControl1.Text);
                komut.Parameters.AddWithValue("@p3", textBox4.Text);
                komut.Parameters.AddWithValue("@p4", textBox33.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Sonuç kayıt edildi.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
