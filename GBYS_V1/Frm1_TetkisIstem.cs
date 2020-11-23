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
    public partial class Frm1_TetkisIstem : DevExpress.XtraEditors.XtraForm
    {
        public static string islemno;
        public static string hastaadi;
        public static string hastasoyadi;

        public Frm1_TetkisIstem()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VADL0P2\SQLEXPRESS;Initial Catalog=GBYS_V1;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;

        void TumTestListesi()
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }

        private void aranan_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara = aranan.Text;
            cumle = "Select * from TEST_TANIMLARI where TEST_ADI like '%" + aranan.Text + "%'";
            SqlDataAdapter adptr = new SqlDataAdapter(cumle, baglanti);
            adptr.Fill(tbl);
            baglanti.Close();
            dataGridView2.DataSource = tbl;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara = aranan.Text;
            cumle = "Select * from TEST_TANIMLARI where SUT_KODU like '%" + textBox2.Text + "%'";
            SqlDataAdapter adptr = new SqlDataAdapter(cumle, baglanti);
            adptr.Fill(tbl);
            baglanti.Close();
            dataGridView2.DataSource = tbl;
        }

        private void KullanıcıID_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("SELECT PERSONEL_ADI + ' ' + PERSONEL_SOYADI FROM KULLANICI_TANIMLARI WHERE KULLANICI_ADI=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", KullanıcıID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                label48.Text = dr[0].ToString();
            }
            baglanti.Close();
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='1- Klinik Genomik'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='2- Herediter Kanserler'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='3- Hematoloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='4- Kardiyoloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='5-Nöroloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='6-Metabolizma ve Endokrinoloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='7-Nefroloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='8-Göz ve Kulak'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='9-Gastroentereloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='10- Romatoloji ve İmmünoloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='11-Patoloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='12- Diğer'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='1 - Klinik PCR'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='2 - Patoloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='Mikrodelesyon FISH'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='Hematoloji FISH'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='Sub Telomere FISH'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='Kromozom Analizleri'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='1- Kardiyoloji'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='2- Diğer'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='3- Sanger'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false;
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from TEST_TANIMLARI where BASLIK='4- Kopya Sayısı Analizi'", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

            this.dataGridView2.Columns["UNITE_ID"].Visible = false;
            this.dataGridView2.Columns["BASLIK"].Visible = false;
            this.dataGridView2.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView2.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView2.Columns["MARKA"].Visible = false;
            this.dataGridView2.Columns["KIT"].Visible = false;
            this.dataGridView2.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView2.Columns["AKTIF"].Visible = false;
            this.dataGridView2.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView2.Columns["LOINC_KODU"].Visible = false; 
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            TumTestListesi();
        }

        private void Frm1_TetkisIstem_Load(object sender, EventArgs e)
        {
            dataGridView3.ColumnCount = 22;
            dataGridView3.Columns[0].Name = "ID";
            dataGridView3.Columns[1].Name = "TEST_ADI";
            dataGridView3.Columns[2].Name = "UNITE_ID";
            dataGridView3.Columns[3].Name = "BASLIK";
            dataGridView3.Columns[4].Name = "UNITE_ADI";
            dataGridView3.Columns[5].Name = "ORNEK_KABI";
            dataGridView3.Columns[6].Name = "ORNEK_TURU";
            dataGridView3.Columns[7].Name = "YONTEM";
            dataGridView3.Columns[8].Name = "LOINC_KODU";
            dataGridView3.Columns[9].Name = "SUT_KODU";
            dataGridView3.Columns[10].Name = "BAGLI_KOD";
            dataGridView3.Columns[11].Name = "BAGLI_KOD2";
            dataGridView3.Columns[12].Name = "SUT_ADI";
            dataGridView3.Columns[13].Name = "SUT_FIYATI";
            dataGridView3.Columns[14].Name = "SUT_PUAN";
            dataGridView3.Columns[15].Name = "GIRIS_SAYISI";
            dataGridView3.Columns[16].Name = "MARKA";
            dataGridView3.Columns[17].Name = "KIT";
            dataGridView3.Columns[18].Name = "BIO_ANALIZ";
            dataGridView3.Columns[19].Name = "GEN_ACIKLAMA";
            dataGridView3.Columns[20].Name = "AKTIF";
            dataGridView3.Columns[21].Name = "HIZMET_GRUP";

            this.dataGridView3.Columns["LOINC_KODU"].Visible = false;
            this.dataGridView3.Columns["ORNEK_KABI"].Visible = false;
            this.dataGridView3.Columns["ORNEK_TURU"].Visible = false;
            this.dataGridView3.Columns["YONTEM"].Visible = false;
            this.dataGridView3.Columns["SUT_PUAN"].Visible = false;
            this.dataGridView3.Columns["UNITE_ID"].Visible = false;
            this.dataGridView3.Columns["BASLIK"].Visible = false;
            this.dataGridView3.Columns["UNITE_ADI"].Visible = false;
            this.dataGridView3.Columns["BAGLI_KOD"].Visible = false;
            this.dataGridView3.Columns["BAGLI_KOD2"].Visible = false;
            this.dataGridView3.Columns["MARKA"].Visible = false;
            this.dataGridView3.Columns["KIT"].Visible = false;
            this.dataGridView3.Columns["BIO_ANALIZ"].Visible = false;
            this.dataGridView3.Columns["AKTIF"].Visible = false;
            this.dataGridView3.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView3.Columns["GIRIS_SAYISI"].Visible = false;
            this.dataGridView3.Columns["GEN_ACIKLAMA"].Visible = false;

            this.dataGridView3.Columns["ID"].Width = 30;
            this.dataGridView3.Columns["SUT_KODU"].Width = 80;
            this.dataGridView3.Columns["SUT_FIYATI"].Width = 80;
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                this.dataGridView3.Rows.Add(rowData);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            {
                //SQŞ GENSEQ prosedüründen Ornek no cekmek için kullanılıyor.
                int ornekno;
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "OrnekNoVer"; //Stored Procedure' ümüzün ismi
                cmd.Parameters.Add("@ORNEKNO", SqlDbType.Int);
                cmd.Parameters["@ORNEKNO"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                ornekno = int.Parse(cmd.Parameters["@ORNEKNO"].Value.ToString());
                ORNEK_NO.Text = ornekno.ToString(); //Stored procedure deki parametrelere
                baglanti.Close();
            }

            dataGridView3.ClearSelection();

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                SqlCommand komut1 = new SqlCommand("insert into LABORATUVAR_ISLEMLERI (ISLEM_NO,KAYIT_TARIHI,BARKOD_BILGI,TEST_ID,ISLEM_ADI,SUT_KODU,SUT_ADI,SUT_FIYATI,LAB_TETKIK,EKLEYEN_KULLANICI,ORNEK_NO,TCKIMLIKNO,HASTA_ADI,HASTA_SOYADI) values (@p1,@p2,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)", baglanti);
                komut1.Parameters.AddWithValue("@p1", ISLEM_NO.Text);
                komut1.Parameters.AddWithValue("@p2", dateTimePicker1.Text);
                komut1.Parameters.AddWithValue("@p4", "BARKOD BASILMADI");
                komut1.Parameters.AddWithValue("@p5", dataGridView3.Rows[i].Cells["ID"].Value.ToString());
                komut1.Parameters.AddWithValue("@p6", dataGridView3.Rows[i].Cells["TEST_ADI"].Value.ToString());
                komut1.Parameters.AddWithValue("@p7", dataGridView3.Rows[i].Cells["SUT_KODU"].Value.ToString());
                komut1.Parameters.AddWithValue("@p8", dataGridView3.Rows[i].Cells["SUT_ADI"].Value.ToString());
                komut1.Parameters.AddWithValue("@p9", dataGridView3.Rows[i].Cells["SUT_FIYATI"].Value.ToString());               
                komut1.Parameters.AddWithValue("@p10", "E");
                komut1.Parameters.AddWithValue("@p11", label48.Text);
                komut1.Parameters.AddWithValue("@p12", ORNEK_NO.Text);
                komut1.Parameters.AddWithValue("@p13", textBox1.Text);
                komut1.Parameters.AddWithValue("@p14", HastaAd.Text);
                komut1.Parameters.AddWithValue("@p15", HastaSoyad.Text);

                baglanti.Open();
                komut1.ExecuteNonQuery();
                baglanti.Close();
            }
            MessageBox.Show("Seçili Testler hasta dosyasına eklenmiştir.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(dataGridView3.SelectedRows.Count > 0)
            {
                dataGridView3.Rows.RemoveAt(dataGridView3.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Lüffen Silinecek Satırı Seçin!");
            }
        }
    }
}
