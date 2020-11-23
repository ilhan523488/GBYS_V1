using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GBYS_V1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public static string kullanıcıbilgisi;
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VADL0P2\SQLEXPRESS;Initial Catalog=GBYS_V1;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM KULLANICI_TANIMLARI where KULLANICI_ADI='" + textBox1.Text + "' AND KULLANICI_SIFRE='" + textBox2.Text + "'  AND AKTIF='E'";
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    kullanıcıbilgisi = textBox1.Text;
                    Form2_AnaMenu fr1 = new Form2_AnaMenu();
                    fr1.Show();
                    fr1.KullanıcıID.Text = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                }
                baglanti.Close();
            }
        }
    }
}
