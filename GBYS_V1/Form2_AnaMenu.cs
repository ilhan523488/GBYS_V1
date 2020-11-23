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
using DevExpress.XtraCharts;
using System.IO;

namespace GBYS_V1
{
    public partial class Form2_AnaMenu : DevExpress.XtraEditors.XtraForm
    {
        public static string islemno;
        public static string testid;
        public static string hastaadi;
        public static string hastasoyadi;
        public static string tckimlikno;

        public Form2_AnaMenu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VADL0P2\SQLEXPRESS;Initial Catalog=GBYS_V1;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        DataSet ds;

        string resimekle;

        bool durum;
        void mukerrerkayıt()
        {
            baglanti.Open();
            komut = new SqlCommand("select * from HASTA_KAYIT_ISLEMLERI where TCKIMLIKNO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TCKIMLIKNO.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();
        }

        void kayıtlarıListele()
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(" SELECT * FROM LABORATUVAR_KAYIT_ISLEMLERI", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            this.dataGridView1.Columns["ISLEM_NO"].Width = 80;
            this.dataGridView1.Columns["DOSYA_NO"].Width = 80;
            this.dataGridView1.Columns["TCKIMLIKNO"].Width = 90;
            this.dataGridView1.Columns["KAYIT_TARIHI"].Width = 120;
            this.dataGridView1.Columns["HASTA_ADI"].Width = 130;
            this.dataGridView1.Columns["HASTA_SOYADI"].Width = 130;
        }

        void ISLEMSORGULA() //ÖRNEK KABUL EKRANINDA ILGILI ALANLARI DOLDURUR
        {
            baglanti.Open();
            //SqlCommand cmd2 = new SqlCommand("select HASTA_ADI from TBL_MURACATKAYIT where KAYITID=@p1", baglanti);
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM LABORATUVAR_KAYIT_ISLEMLERI WHERE ISLEM_NO=@p1", baglanti);
            cmd2.Parameters.AddWithValue("@p1", ISLEM_NO.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                textBox13.Text = dr["HASTA_ADI"].ToString();
                textBox12.Text = dr["HASTA_SOYADI"].ToString();
                textBox11.Text = dr["TCKIMLIKNO"].ToString();
                textBox10.Text = dr["ACIKLAMA"].ToString();
            }
            baglanti.Close();
        }

        void TCSORGLA()
        {
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM HASTA_KAYIT_ISLEMLERI WHERE TCKIMLIKNO=@p1", baglanti);
            cmd2.Parameters.AddWithValue("@p1", textBox11.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                comboBox4.Text = dr["CINSIYET"].ToString();
                textBox7.Text = dr["YAS"].ToString();
            }
            baglanti.Close();
        }

        void TESTBILGILERI()
        {
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM TEST_TANIMLARI WHERE ID=@p1", baglanti);
            cmd2.Parameters.AddWithValue("@p1", TestID.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                TupBilgisi.Text = dr["ORNEK_KABI"].ToString();
                TestGrupAdi.Text = dr["UNITE_ADI"].ToString();
                CalismaYontemi.Text = dr["YONTEM"].ToString();
                Kit.Text = dr["KIT"].ToString();
                textBox2.Text = dr["BIO_ANALIZ"].ToString();
                textBox3.Text = dr["GEN_ACIKLAMA"].ToString();
            }
            baglanti.Close();
        }

        void labkayitlariListele()
        {
            if (ISLEMNO.Text == "")
            {
                MessageBox.Show("Lütfen İşlem numarası giriniz.");
            }
            else
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(" SELECT * FROM LABORATUVAR_KAYIT_ISLEMLERI where ISLEM_NO=" + ISLEMNO.Text, baglanti);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
        }

        void BarkodBasildiBilgisi()
        {
            baglanti.Open();
            dataGridView3.ClearSelection();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from LABORATUVAR_ISLEMLERI WHERE ORNEK_NO= '" + ORNEK_NO.Text + "'", baglanti);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            baglanti.Close();
        }


        void HastaAra()
        {
            if (TCKIMLIKNO.Text == "")
            {
                MessageBox.Show("Arama yapmak T.C Kimlik numarasını giriniz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                {
                    baglanti.Open();
                    //SqlCommand cmd2 = new SqlCommand("select HASTA_ADI from TBL_MURACATKAYIT where KAYITID=@p1", baglanti);
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM HASTA_KAYIT_ISLEMLERI WHERE TCKIMLIKNO=@p1", baglanti);
                    cmd2.Parameters.AddWithValue("@p1", TCKIMLIKNO.Text);
                    SqlDataReader dr = cmd2.ExecuteReader();
                    if (dr.Read())
                    {
                        DOSYANO.Text = dr["DOSYA_NO"].ToString();
                        HASTAADI.Text = dr["HASTA_ADI"].ToString();
                        HASTASOYADI.Text = dr["HASTA_SOYADI"].ToString();
                        BABAADI.Text = dr["BABA_ADI"].ToString();
                        ANAADI.Text = dr["ANA_ADI"].ToString();
                        CEPTELEFONU.Text = dr["CEPTELEFONU"].ToString();
                        EPOSTAADRES.Text = dr["EPOSTAADRES"].ToString();
                        DOGUMYERI.Text = dr["DOGUM_YERI"].ToString();
                        DOGUMILI.Text = dr["DOGUM_ILI"].ToString();
                        DOGUMILCE.Text = dr["DOGUM_ILCE"].ToString();
                        DOGUMTARIHI.Text = dr["DOGUM_TARIHI"].ToString();
                        CINSIYET.Text = dr["CINSIYET"].ToString();
                        YAS.Text = dr["YAS"].ToString();
                        MEDENIHALI.Text = dr["MEDENI_HALI"].ToString();
                        ADRES.Text = dr["ADRES"].ToString();
                    }
                    baglanti.Close();
                }
            }
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form2_AnaMenu fr1 = new Form2_AnaMenu();
            fr1.Close();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage2.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;

            xtraTabPage3.PageVisible = false;
            xtraTabPage4.PageVisible = false;
            xtraTabPage5.PageVisible = false;
            xtraTabPage6.PageVisible = false;
            xtraTabPage7.PageVisible = false;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage3.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage3;

            xtraTabPage1.PageVisible = false;
            xtraTabPage2.PageVisible = false;
            xtraTabPage4.PageVisible = false;
            xtraTabPage5.PageVisible = false;
            xtraTabPage6.PageVisible = false;
            xtraTabPage7.PageVisible = false;
        }

        private void Form_AnaMenu_Load(object sender, EventArgs e)
        {

            Anamenu.PageVisible = true;
            xtraTabControl1.SelectedTabPage = Anamenu;

            xtraTabPage1.PageVisible = false;
            xtraTabPage2.PageVisible = false;
            xtraTabPage3.PageVisible = false;
            xtraTabPage4.PageVisible = false;
            xtraTabPage5.PageVisible = false;
            xtraTabPage6.PageVisible = false;
            xtraTabPage7.PageVisible = false;
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (TCKIMLIKNO.Text == "")
            {
                MessageBox.Show("T.C Kimlik numarasının girilmesi zorunludur.");
            }
            else
            {
                mukerrerkayıt();
                if (durum == true)
                {
                    SqlCommand komut = new SqlCommand("insert into HASTA_KAYIT_ISLEMLERI (KAYIT_TARIHI,TCKIMLIKNO,HASTA_ADI,HASTA_SOYADI,BABA_ADI,ANA_ADI,CEPTELEFONU,EPOSTAADRES,DOGUM_YERI,DOGUM_ILI,DOGUM_ILCE,DOGUM_TARIHI,CINSIYET,YAS,MEDENI_HALI,ADRES,KAYIT_OLUSTURAN) values (@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18)", baglanti);
                    //komut.Parameters.AddWithValue("@p1", DOSYANO.Text);
                    komut.Parameters.AddWithValue("@p2", KAYITTARIHI.Text);
                    komut.Parameters.AddWithValue("@p3", TCKIMLIKNO.Text);
                    komut.Parameters.AddWithValue("@p4", HASTAADI.Text);
                    komut.Parameters.AddWithValue("@p5", HASTASOYADI.Text);
                    komut.Parameters.AddWithValue("@p6", BABAADI.Text);
                    komut.Parameters.AddWithValue("@p7", ANAADI.Text);
                    komut.Parameters.AddWithValue("@p8", CEPTELEFONU.Text);
                    komut.Parameters.AddWithValue("@p9", EPOSTAADRES.Text);
                    komut.Parameters.AddWithValue("@p10", DOGUMYERI.Text);
                    komut.Parameters.AddWithValue("@p11", DOGUMILI.Text);
                    komut.Parameters.AddWithValue("@p12", DOGUMILCE.Text);
                    komut.Parameters.AddWithValue("@p13", DOGUMTARIHI.Text);
                    komut.Parameters.AddWithValue("@p14", CINSIYET.Text);
                    komut.Parameters.AddWithValue("@p15", YAS.Text);
                    komut.Parameters.AddWithValue("@p16", MEDENIHALI.Text);
                    komut.Parameters.AddWithValue("@p17", ADRES.Text);
                    komut.Parameters.AddWithValue("@p18", label48.Text);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hasta Kayıt Edildi. Lütfen Laboratuvar bilgilerini giriniz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Müracat İd çekme
                    baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("select top 1 DOSYA_NO from HASTA_KAYIT_ISLEMLERI order by DOSYA_NO desc", baglanti);
                    SqlDataReader dr1 = komut3.ExecuteReader();
                    while (dr1.Read())
                    {
                        DOSYANO.Text = dr1[0].ToString();
                    }
                    baglanti.Close();
                }
                else
                {
                    DialogResult secenek = MessageBox.Show("Bu T.C Kimlik numaralı hasta sistemde kayıtlı. Hastayı ekrana almak istiyor musunuz?", "Bilgi Ekranı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (secenek == DialogResult.Yes)
                    {
                        baglanti.Open();
                        SqlDataAdapter sorgula = new SqlDataAdapter("select * from HASTA_KAYIT_ISLEMLERI where TCKIMLIKNO='" + TCKIMLIKNO.Text + "' ", baglanti);
                        DataTable tablo = new DataTable();
                        sorgula.Fill(tablo);
                        DOSYANO.Text = tablo.Rows[0][0].ToString();
                        KAYITTARIHI.Text = tablo.Rows[0][1].ToString();
                        TCKIMLIKNO.Text = tablo.Rows[0][2].ToString();
                        HASTAADI.Text = tablo.Rows[0][3].ToString();
                        HASTASOYADI.Text = tablo.Rows[0][4].ToString();
                        BABAADI.Text = tablo.Rows[0][5].ToString();
                        ANAADI.Text = tablo.Rows[0][6].ToString();
                        CEPTELEFONU.Text = tablo.Rows[0][7].ToString();
                        EPOSTAADRES.Text = tablo.Rows[0][8].ToString();
                        DOGUMYERI.Text = tablo.Rows[0][9].ToString();
                        DOGUMILI.Text = tablo.Rows[0][10].ToString();
                        DOGUMILCE.Text = tablo.Rows[0][11].ToString();
                        DOGUMTARIHI.Text = tablo.Rows[0][12].ToString();
                        CINSIYET.Text = tablo.Rows[0][13].ToString();
                        YAS.Text = tablo.Rows[0][14].ToString();
                        MEDENIHALI.Text = tablo.Rows[0][15].ToString();
                        ADRES.Text = tablo.Rows[0][16].ToString();
                    }
                    if (secenek == DialogResult.No)
                    {
                        TCKIMLIKNO.Clear();
                        TCKIMLIKNO.Focus();
                    }
                    baglanti.Close();
                }

            }
        }

        private void SIL_Click(object sender, EventArgs e)
        {
            if (DOSYANO.Text == "")
            {
                MessageBox.Show("Lütfen Güncellenecek dosya numarası seçiniz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult secenek = MessageBox.Show("Seçili kayıt silinecektir.Emin misiniz ? ", "SİLME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secenek == DialogResult.Yes)
                {
                    string sorgu = "DELETE FROM HASTA_KAYIT_ISLEMLERI WHERE DOSYA_NO=@p1";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@p1", Convert.ToInt32(DOSYANO.Text));
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Seçili Kayıt Silindi", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (secenek == DialogResult.No)
                {
                    //
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ISLEMNO.Text = dataGridView1.CurrentRow.Cells["ISLEM_NO"].Value.ToString();
                TCKIMLIKNO.Text = dataGridView1.CurrentRow.Cells["TCKIMLIKNO"].Value.ToString();
                DOSYANO.Text = dataGridView1.CurrentRow.Cells["DOSYA_NO"].Value.ToString();
                HASTAADI.Text = dataGridView1.CurrentRow.Cells["HASTA_ADI"].Value.ToString();
                HASTASOYADI.Text = dataGridView1.CurrentRow.Cells["HASTA_SOYADI"].Value.ToString();
            }
            else
            {
                //
            }
        }

        void kayıtsorgula()
        {
            baglanti.Open();
            komut = new SqlCommand("select * from HASTA_KAYIT_ISLEMLERI where TCKIMLIKNO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TCKIMLIKNO.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            kayıtsorgula();
            if(durum == false)
            {
                HastaResim.Image = null;
                HastaAra();
                resimgoster();
            }
            else
            {
                DialogResult secenek = MessageBox.Show("Kayıt Bulunamadı yeni kayıt oluşturma ister misiniz ?", "Bilgi Ekranı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secenek == DialogResult.Yes)
                {

                    TCKIMLIKNO.Focus();
                    DOSYANO.Clear();
                    HASTAADI.Clear();
                    HASTASOYADI.Clear();
                    BABAADI.Clear();
                    ANAADI.Clear();
                    CEPTELEFONU.Clear();
                    DOGUMTARIHI.Text = "";
                    KAYITTARIHI.Text = "";
                    DOGUMYERI.Clear();
                    CINSIYET.Text = "";
                    YAS.Clear();
                    MEDENIHALI.Text = "";
                    DOGUMILI.Text = "";
                    DOGUMILCE.Text = "";
                    ADRES.Clear();
                    ISLEMNO.Text = "";
                    EPOSTAADRES.Text = "";
                    HastaResim.Image = null;
                }
                if (secenek == DialogResult.No)
                {
                    //
                }
                baglanti.Close();
            }

        }

        private void GUNCELLE_Click(object sender, EventArgs e)
        {
            if (DOSYANO.Text == "")
            {
                MessageBox.Show("Lütfen Güncellenecek dosya numarası seçiniz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult secenek = MessageBox.Show("Seçili kayıt güncellenecektir.Emin misiniz ? ", "GÜNCELLEME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secenek == DialogResult.Yes)
                {
                    string sorgu = "UPDATE HASTA_KAYIT_ISLEMLERI SET KAYIT_TARIHI=@p2,TCKIMLIKNO=@p3,HASTA_ADI=@p4,HASTA_SOYADI=@p5,BABA_ADI=@p6,ANA_ADI=@p7,CEPTELEFONU=@p8,EPOSTAADRES=@p9,DOGUM_YERI=@p10,DOGUM_ILI=@p11,DOGUM_ILCE=@p12,DOGUM_TARIHI=@p13,CINSIYET=@p14,YAS=@p15,MEDENI_HALI=@p16,ADRES=@p17 WHERE DOSYA_NO=@DOSYANO";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@DOSYANO", Convert.ToInt32(DOSYANO.Text));
                    komut.Parameters.AddWithValue("@p2", KAYITTARIHI.Text);
                    komut.Parameters.AddWithValue("@p3", TCKIMLIKNO.Text);
                    komut.Parameters.AddWithValue("@p4", HASTAADI.Text);
                    komut.Parameters.AddWithValue("@p5", HASTASOYADI.Text);
                    komut.Parameters.AddWithValue("@p6", BABAADI.Text);
                    komut.Parameters.AddWithValue("@p7", ANAADI.Text);
                    komut.Parameters.AddWithValue("@p8", CEPTELEFONU.Text);
                    komut.Parameters.AddWithValue("@p9", EPOSTAADRES.Text);
                    komut.Parameters.AddWithValue("@p10", DOGUMYERI.Text);
                    komut.Parameters.AddWithValue("@p11", DOGUMILI.Text);
                    komut.Parameters.AddWithValue("@p12", DOGUMILCE.Text);
                    komut.Parameters.AddWithValue("@p13", DOGUMTARIHI.Text);
                    komut.Parameters.AddWithValue("@p14", CINSIYET.Text);
                    komut.Parameters.AddWithValue("@p15", YAS.Text);
                    komut.Parameters.AddWithValue("@p16", MEDENIHALI.Text);
                    komut.Parameters.AddWithValue("@p17", ADRES.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Seçili Kayıt Güncellendi", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (secenek == DialogResult.No)
                {
                    //
                }
            }
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            TCKIMLIKNO.Clear();
            DOSYANO.Clear();
            HASTAADI.Clear();
            HASTASOYADI.Clear();
            BABAADI.Clear();
            ANAADI.Clear();
            CEPTELEFONU.Clear();
            DOGUMTARIHI.Text = "";
            KAYITTARIHI.Text = "";
            DOGUMYERI.Clear();
            CINSIYET.Text = "";
            YAS.Clear();
            MEDENIHALI.Text = "";
            DOGUMILI.Text = "";
            DOGUMILCE.Text = "";
            ADRES.Clear();
            ISLEMNO.Text = "";
            EPOSTAADRES.Text = "";
            HastaResim.Image = null;
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

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage4.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage4;

            xtraTabPage1.PageVisible = false;
            xtraTabPage2.PageVisible = false;
            xtraTabPage3.PageVisible = false;
            xtraTabPage5.PageVisible = false;
            xtraTabPage6.PageVisible = false;
            xtraTabPage7.PageVisible = false;
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage1.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage1;

            xtraTabPage2.PageVisible = false;
            xtraTabPage3.PageVisible = false;
            xtraTabPage4.PageVisible = false;
            xtraTabPage5.PageVisible = false;
            xtraTabPage6.PageVisible = false;
            xtraTabPage7.PageVisible = false;

        }

        bool durum1;
        void OrnekSorgula()
        {
            baglanti.Open();
            komut = new SqlCommand("select * from LABORATUVAR_ISLEMLERI where ORNEK_NO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", ORNEK_NO.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum1 = false;
            }
            else
            {
                durum1 = true;
            }
            baglanti.Close();
        }


        private void simpleButton46_Click(object sender, EventArgs e)
        {
            if (ORNEK_NO.Text == "")
            {
                MessageBox.Show("Lütfen ! Arama yapmak için  örnek numarası giriniz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OrnekSorgula();

                if (durum1 == false)
                {
                    baglanti.Open();
                    SqlDataAdapter sorgula = new SqlDataAdapter("select * from LABORATUVAR_ISLEMLERI where ORNEK_NO='" + ORNEK_NO.Text + "' ", baglanti);
                    DataTable dt = new DataTable();
                    sorgula.Fill(dt);
                    dataGridView3.DataSource = dt;
                    baglanti.Close();

                    //ilgili textboxları doldurur.
                    ISLEM_NO.Text = dt.Rows[0][1].ToString();

                    this.dataGridView3.Columns["KAYIT_ID"].Visible = false;
                    this.dataGridView3.Columns["LAB_TETKIK"].Visible = false;
                    this.dataGridView3.Columns["HIZMET_GRUP"].Visible = false;
                    this.dataGridView3.Columns["TEKNISYEN_ONAY"].Visible = false;
                    this.dataGridView3.Columns["TEKNISYEN_ONAY_TARIH"].Visible = false;
                    this.dataGridView3.Columns["ONAYLAYAN_TEKNİSYEN"].Visible = false;
                    this.dataGridView3.Columns["UZMAN_ONAY"].Visible = false;
                    this.dataGridView3.Columns["UZMAN_ONAY_TARIH"].Visible = false;
                    this.dataGridView3.Columns["ONAYLAYAN_UZMAN"].Visible = false;
                    this.dataGridView3.Columns["TEST_DURUM"].Visible = false;
                    this.dataGridView3.Columns["TEST_BASLATAN"].Visible = false;
                    this.dataGridView3.Columns["TEST_BASLAMA_TARIHI"].Visible = false;
                    this.dataGridView3.Columns["ORNEK_TEKRAR_VEREN"].Visible = false;
                    this.dataGridView3.Columns["ORNEK_TEKRAR_TARIHI"].Visible = false;
                    this.dataGridView3.Columns["ARSIV_NO"].Visible = false;
                    this.dataGridView3.Columns["TEKRAR_NEDENİ"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Örnek bulunamadı.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ISLEMSORGULA();
            TCSORGLA();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ISLEMNO.Text == "")
            {
                //
            }
            else
            {
                islemno = ISLEMNO.Text;
                tckimlikno = TCKIMLIKNO.Text;
                hastaadi = HASTAADI.Text;
                hastasoyadi = HASTASOYADI.Text;
                Frm1_TetkisIstem fr2 = new Frm1_TetkisIstem();
                fr2.Show();
                fr2.ISLEM_NO.Text = ISLEMNO.Text;
                fr2.textBox1.Text = TCKIMLIKNO.Text;
                fr2.HastaAd.Text = HASTAADI.Text;
                fr2.HastaSoyad.Text = HASTASOYADI.Text;
                fr2.KullanıcıID.Text = KullanıcıID.Text;

            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            {
                if (DOSYANO.Text == "")
                {
                    MessageBox.Show("Lütfen Müracaat bilgisi seçiniz", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlCommand komut1 = new SqlCommand("insert into LABORATUVAR_KAYIT_ISLEMLERI (DOSYA_NO,TCKIMLIKNO,HASTA_ADI,HASTA_SOYADI,LABORATUVAR_ADI,KAYIT_TARIHI,ACIKLAMA) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
                    komut1.Parameters.AddWithValue("@p1", DOSYANO.Text);
                    komut1.Parameters.AddWithValue("@p2", TCKIMLIKNO.Text);
                    komut1.Parameters.AddWithValue("@p3", HASTAADI.Text);
                    komut1.Parameters.AddWithValue("@p4", HASTASOYADI.Text);
                    komut1.Parameters.AddWithValue("@p5", textBox5.Text);
                    komut1.Parameters.AddWithValue("@p6", KAYITTARIHI.Text);
                    komut1.Parameters.AddWithValue("@p7", textBox1.Text);
                    baglanti.Open();
                    komut1.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("select top 1 ISLEM_NO from LABORATUVAR_KAYIT_ISLEMLERI order by ISLEM_NO desc", baglanti);
                    SqlDataReader dr1 = komut3.ExecuteReader();
                    while (dr1.Read())
                    {
                        ISLEMNO.Text = dr1[0].ToString();
                    }
                    baglanti.Close();
                    labkayitlariListele();
                }
            }
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            if (ISLEM_NO.Text == "")
            {
                MessageBox.Show("LÜTFEN! işlem numarasını giriniz");
            }
            else
            {
                baglanti.Open();
                string kayit = "update LABORATUVAR_ISLEMLERI set ORNEK_KABULEDEN=@p1,ORNEK_KABULTARIH=@p2,BARKOD_BILGI=@p4,FATURALANDI=@p5,ORNEK_KABUL=@p6 where ISLEM_NO=@p3";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@p1", label48.Text);
                komut.Parameters.AddWithValue("@p2", dateTimePicker10.Text);
                komut.Parameters.AddWithValue("@p4", "ORNEK KABUL EDİLDİ");
                komut.Parameters.AddWithValue("@p5", "H");
                komut.Parameters.AddWithValue("@p6", "E");
                komut.Parameters.AddWithValue("@p3", ISLEM_NO.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Örnek kabul işlemi yapılmıştır.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BarkodBasildiBilgisi();
            }
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.Equals("BARKOD BASILDI"))
                {
                    e.CellStyle.BackColor = Color.Aquamarine;
                    e.CellStyle.SelectionBackColor = Color.Aquamarine;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
                if (e.Value.Equals("ORNEK KABUL EDİLDİ"))
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.SelectionBackColor = Color.Yellow;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
                if (e.Value.Equals("NUMUNE RED EDİLDİ"))
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.SelectionBackColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
                else if (e.Value.Equals("BARKOD BASILMADI"))
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.SelectionBackColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (ISLEM_NO.Text == "")
            {
                MessageBox.Show("LÜTFEN! işlem numarasını giriniz");
            }
            else
            {
                baglanti.Open();
                string kayit = "update LABORATUVAR_ISLEMLERI set BARKOD_BILGI=@p1 where ISLEM_NO=@p2";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@p1", "BARKOD BASILDI");
                komut.Parameters.AddWithValue("@p2", ISLEM_NO.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                BarkodBasildiBilgisi();
            }
        }
        private void dataGridView3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                TestID.Text = dataGridView3.CurrentRow.Cells["TEST_ID"].Value.ToString();
            }
            else
            {
                TestID.Text = dataGridView3.CurrentRow.Cells["TEST_ID"].Value.ToString();
            }
        }

        private void TestID_TextChanged(object sender, EventArgs e)
        {
            TESTBILGILERI();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (TestID.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Numune RED bilgisinin girilmesi zorunludur", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dataGridView3.RowCount > 0)
                {
                    SqlCommand NumuneRed = new SqlCommand("UPDATE LABORATUVAR_ISLEMLERI SET NUMUNE_RED_EDEN=@p2,NUMUNE_RED_TARIHI=@p3,BARKOD_BILGI=@p4,NUMUNE_RED_ACIKLAMA=@p5,NUMUNE_RED=@p6 WHERE TEST_ID =@p1", baglanti);
                    NumuneRed.Parameters.AddWithValue("@p1", TestID.Text);
                    NumuneRed.Parameters.AddWithValue("@p2", label48.Text);
                    NumuneRed.Parameters.AddWithValue("@p4", "NUMUNE RED EDİLDİ");
                    NumuneRed.Parameters.AddWithValue("@p5", comboBox7.Text);
                    NumuneRed.Parameters.AddWithValue("@p6", "E");
                    NumuneRed.Parameters.AddWithValue("@p3", dateTimePicker10.Text);
                    baglanti.Open();
                    NumuneRed.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Numune RED edilmiştir.");
                    BarkodBasildiBilgisi();
                }
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            kayıtlarıListele();
        }

        void ISLEMSORGULA1() //ÖRNEK KABUL EKRANINDA ILGILI ALANLARI DOLDURUR
        {
            baglanti.Open();
            //SqlCommand cmd2 = new SqlCommand("select HASTA_ADI from TBL_MURACATKAYIT where KAYITID=@p1", baglanti);
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM LABORATUVAR_KAYIT_ISLEMLERI WHERE ISLEM_NO=@p1", baglanti);
            cmd2.Parameters.AddWithValue("@p1", textBox4.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                textBox13.Text = dr["HASTA_ADI"].ToString();
                textBox12.Text = dr["HASTA_SOYADI"].ToString();
                textBox11.Text = dr["TCKIMLIKNO"].ToString();
                textBox10.Text = dr["ACIKLAMA"].ToString();
            }
            baglanti.Close();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                textBox40.Text = dataGridView2.CurrentRow.Cells["TCKIMLIKNO"].Value.ToString();
                textBox4.Text = dataGridView2.CurrentRow.Cells["ISLEM_NO"].Value.ToString();
            }
            else
            {
                //
            }
        }

        void TESTBILGILERI1()
        {
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM TEST_TANIMLARI WHERE ID=@p1", baglanti);
            cmd2.Parameters.AddWithValue("@p1", textBox33.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                textBox15.Text = dr["ORNEK_KABI"].ToString();
                textBox14.Text = dr["UNITE_ADI"].ToString();
                textBox16.Text = dr["YONTEM"].ToString();
                textBox9.Text = dr["KIT"].ToString();
                textBox6.Text = dr["BIO_ANALIZ"].ToString();
                textBox17.Text = dr["GEN_ACIKLAMA"].ToString();
            }
            baglanti.Close();
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            TESTBILGILERI1();
        }

        private void Anamenu_Paint(object sender, PaintEventArgs e)
        {

        }

        void TCSORGLA1()
        {
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM HASTA_KAYIT_ISLEMLERI WHERE TCKIMLIKNO=@p1", baglanti);
            cmd2.Parameters.AddWithValue("@p1", textBox40.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                comboBox9.Text = dr["CINSIYET"].ToString();
                textBox38.Text = dr["YAS"].ToString();
                textBox41.Text = dr["HASTA_ADI"].ToString();
                textBox42.Text = dr["HASTA_SOYADI"].ToString();
                textBox18.Text = dr["CEPTELEFONU"].ToString();
                textBox19.Text = dr["EPOSTAADRES"].ToString();
            }
            baglanti.Close();
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            TCSORGLA1();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                SqlDataAdapter sorgula = new SqlDataAdapter("select * from LABORATUVAR_KAYIT_ISLEMLERI", baglanti);
                DataTable dt = new DataTable();
                sorgula.Fill(dt);
                dataGridView2.DataSource = dt;
                baglanti.Close();
                //SUTUNLARI GİZLER
                this.dataGridView2.Columns["DOSYA_NO"].Visible = false;
                this.dataGridView2.Columns["ACIKLAMA"].Visible = false;
                this.dataGridView2.Columns["LABORATUVAR_ADI"].Visible = false;

                this.dataGridView2.Columns["ISLEM_NO"].Width = 80;
            }
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                textBox33.Text = dataGridView4.CurrentRow.Cells["TEST_ID"].Value.ToString();
                textBox40.Text = dataGridView4.CurrentRow.Cells["TCKIMLIKNO"].Value.ToString();
                textBox4.Text = dataGridView4.CurrentRow.Cells["ISLEM_NO"].Value.ToString();
            }
            else
            {
                //
            }
        }

        void TetkikleriListele()
        {
            baglanti.Open();
            SqlDataAdapter sorgula = new SqlDataAdapter("select * from LABORATUVAR_ISLEMLERI where ISLEM_NO='" + textBox4.Text + "'", baglanti);
            DataTable dt = new DataTable();
            sorgula.Fill(dt);
            dataGridView4.DataSource = dt;
            baglanti.Close();
            this.dataGridView4.Columns["KAYIT_ID"].Visible = false;
            this.dataGridView4.Columns["ISLEM_NO"].Visible = false;
            this.dataGridView4.Columns["TCKIMLIKNO"].Visible = false;
            this.dataGridView4.Columns["HASTA_ADI"].Visible = false;
            this.dataGridView4.Columns["HASTA_SOYADI"].Visible = false;

            this.dataGridView4.Columns["LAB_TETKIK"].Visible = false;
            this.dataGridView4.Columns["HIZMET_GRUP"].Visible = false;
            this.dataGridView4.Columns["ISLEM_NO"].Width = 75;

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TetkikleriListele();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            dt.Clear();
            da = new SqlDataAdapter("select * from LABORATUVAR_ISLEMLERI WHERE ORNEK_KABUL='E'", baglanti);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            baglanti.Close();
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true; // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsView.ShowFooter = true; // alt toplam gibi bilgileri gösterilebilmesi için en alta bir alan açar
            this.gridView1.OptionsView.ColumnAutoWidth = false; //kolonları sağa doğru kolon başlığı yada hücre verisine göre
            this.gridView1.ColumnPanelRowHeight = 30; //gridview header yüksekliği
            this.gridView1.OptionsView.ShowGroupPanel = false; // kolon başlıklarının üzerinde bir gruplama alanı açar
            this.gridView1.BestFitColumns();

            gridView1.Columns["KAYIT_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns["KAYIT_ID"].SummaryItem.DisplayFormat = "{0}";
            gridView1.Columns["KAYIT_ID"].SummaryItem.Tag = 1;
            // bu 3 satır gridin ve RECNO kolonun en altına kayıt adedini gösterir.

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DOGUMTARIHI_ValueChanged(object sender, EventArgs e)
        {
            int yas;
            DateTime dogumtarihi;
            dogumtarihi = Convert.ToDateTime(DOGUMTARIHI.Text);
            yas = DateTime.Now.Year - dogumtarihi.Year;
            YAS.Text = "" + yas.ToString() + "";
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage5.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage5;

            xtraTabPage1.PageVisible = false;
            xtraTabPage2.PageVisible = false;
            xtraTabPage3.PageVisible = false;
            xtraTabPage4.PageVisible = false;
            xtraTabPage6.PageVisible = false;
            xtraTabPage7.PageVisible = false;
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage6.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage6;

            xtraTabPage1.PageVisible = false;
            xtraTabPage2.PageVisible = false;
            xtraTabPage3.PageVisible = false;
            xtraTabPage4.PageVisible = false;
            xtraTabPage5.PageVisible = false;
            xtraTabPage7.PageVisible = false;
        }

        private void navBarItem8_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage7.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage7;

            xtraTabPage1.PageVisible = false;
            xtraTabPage2.PageVisible = false;
            xtraTabPage3.PageVisible = false;
            xtraTabPage4.PageVisible = false;
            xtraTabPage5.PageVisible = false;
            xtraTabPage6.PageVisible = false;
        }

        void faturalanacakhasta()
        {
            baglanti.Open();
            SqlDataAdapter sorgula = new SqlDataAdapter("select * from LABORATUVAR_KAYIT_ISLEMLERI WHERE DOSYA_NO='" + textBox31.Text + "' ", baglanti);
            DataTable dt = new DataTable();
            sorgula.Fill(dt);
            dataGridView6.DataSource = dt;
            baglanti.Close();
            //SUTUNLARI GİZLER
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                SqlDataAdapter sorgula = new SqlDataAdapter("select * from HASTA_KAYIT_ISLEMLERI", baglanti);
                DataTable dt = new DataTable();
                sorgula.Fill(dt);
                dataGridView5.DataSource = dt;
                baglanti.Close();

                this.dataGridView5.Columns["BABA_ADI"].Visible = false;
                this.dataGridView5.Columns["ANA_ADI"].Visible = false;
                this.dataGridView5.Columns["CEPTELEFONU"].Visible = false;
                this.dataGridView5.Columns["EPOSTAADRES"].Visible = false;
                this.dataGridView5.Columns["DOGUM_YERI"].Visible = false;
                this.dataGridView5.Columns["DOGUM_ILI"].Visible = false;
                this.dataGridView5.Columns["DOGUM_ILCE"].Visible = false;
                this.dataGridView5.Columns["DOGUM_TARIHI"].Visible = false;
                this.dataGridView5.Columns["MEDENI_HALI"].Visible = false;
                this.dataGridView5.Columns["ADRES"].Visible = false;
                this.dataGridView5.Columns["KAYIT_OLUSTURAN"].Visible = false;

            }
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            faturalanacakhasta();
        }

        private void dataGridView5_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count > 0)
            {
                textBox31.Text = dataGridView5.CurrentRow.Cells["DOSYA_NO"].Value.ToString();
                textBox32.Text = dataGridView5.CurrentRow.Cells["TCKIMLIKNO"].Value.ToString();
                textBox34.Text = dataGridView5.CurrentRow.Cells["HASTA_ADI"].Value.ToString();
                textBox35.Text = dataGridView5.CurrentRow.Cells["HASTA_SOYADI"].Value.ToString();
                textBox30.Text = dataGridView5.CurrentRow.Cells["YAS"].Value.ToString();
                comboBox1.Text = dataGridView5.CurrentRow.Cells["CINSIYET"].Value.ToString();
                textBox22.Text = dataGridView5.CurrentRow.Cells["CEPTELEFONU"].Value.ToString();
                textBox21.Text = dataGridView5.CurrentRow.Cells["EPOSTAADRES"].Value.ToString();
            }
            else
            {
                textBox31.Text = dataGridView5.CurrentRow.Cells["DOSYA_NO"].Value.ToString();
                textBox32.Text = dataGridView5.CurrentRow.Cells["TCKIMLIKNO"].Value.ToString();
                textBox34.Text = dataGridView5.CurrentRow.Cells["HASTA_ADI"].Value.ToString();
                textBox35.Text = dataGridView5.CurrentRow.Cells["HASTA_SOYADI"].Value.ToString();
                textBox30.Text = dataGridView5.CurrentRow.Cells["YAS"].Value.ToString();
                comboBox1.Text = dataGridView5.CurrentRow.Cells["CINSIYET"].Value.ToString();
                textBox22.Text = dataGridView5.CurrentRow.Cells["CEPTELEFONU"].Value.ToString();
                textBox21.Text = dataGridView5.CurrentRow.Cells["EPOSTAADRES"].Value.ToString();
            }
        }

        private void dataGridView6_Click(object sender, EventArgs e)
        {
            if (dataGridView6.SelectedRows.Count > 0)
            {
                textBox23.Text = dataGridView6.CurrentRow.Cells["ISLEM_NO"].Value.ToString();
            }
            else
            {
                //
            }
        }

        void FATURALACAKTESTLER()
        {
            if (ISLEMNO.Text == "")
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(" SELECT * FROM LABORATUVAR_ISLEMLERI where ISLEM_NO=" + textBox23.Text, baglanti);
                da.Fill(dt);
                dataGridView7.DataSource = dt;
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Lütfen İşlem numarası giriniz.");
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            FATURALACAKTESTLER();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox20.Text = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {
            ArsivSorgula();
        }

        void ArsivSorgula()
        {
            if (textBox20.Text == "")
            {
                MessageBox.Show("Lütfen ! Dolap Seçiniz", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(" SELECT * FROM DNA_ARSIV where DOLAP_NO='" + textBox20.Text + "'", baglanti);
                da.Fill(dt);
                dataGridView8.DataSource = dt;
                baglanti.Close();

                this.dataGridView8.Columns["ID"].Width = 30;
                this.dataGridView8.Columns["RAF_NO"].Width = 40;
                this.dataGridView8.Columns["RAF_SIRA_NO"].Width = 45;
                this.dataGridView8.Columns["DOLULUK"].Width = 60;
                this.dataGridView8.Columns["DOLAP_NO"].Width = 90;
                this.dataGridView8.Columns["ORNEK_NO"].Width = 60;
                this.dataGridView8.Columns["ISLEM_NO"].Width = 60;
                this.dataGridView8.Columns["DOLULUK"].Width = 60;

                this.dataGridView8.Columns["DOLAP_NO"].HeaderText = "DOLAP";
                this.dataGridView8.Columns["ISLEM_NO"].HeaderText = "İŞLEM NO";
                this.dataGridView8.Columns["RAF_NO"].HeaderText = "RAF";
                this.dataGridView8.Columns["RAF_SIRA_NO"].HeaderText = "RAF SIRA";
                this.dataGridView8.Columns["DOLULUK"].HeaderText = "DOLULUK";
                this.dataGridView8.Columns["ORNEK_NO"].HeaderText = "ORNEK NO";
                this.dataGridView8.Columns["HASTA_ADI"].HeaderText = "HASTA AD";
                this.dataGridView8.Columns["HASTA_SOYADI"].HeaderText = "HASTA SOYAD";
            }

        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            if (textBox24.Text == "")
            {
                //
            }
            else
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(" SELECT * FROM LABORATUVAR_ISLEMLERI where ORNEK_NO='" + textBox24.Text + "'", baglanti);
                da.Fill(dt);
                dataGridView9.DataSource = dt;
                baglanti.Close();

                this.dataGridView9.Columns["ISLEM_NO"].Width = 80;

                this.dataGridView9.Columns["KAYIT_ID"].Visible = false;
                this.dataGridView9.Columns["TEST_ID"].Visible = false;
                this.dataGridView9.Columns["ISLEM_ADI"].Visible = false;
                this.dataGridView9.Columns["SUT_KODU"].Visible = false;
                this.dataGridView9.Columns["SUT_FIYATI"].Visible = false;
                this.dataGridView9.Columns["SUT_ADI"].Visible = false;
                this.dataGridView9.Columns["BARKOD_BILGI"].Visible = false;
                this.dataGridView9.Columns["KAYIT_TARIHI"].Visible = false;
                this.dataGridView9.Columns["FATURALANDI"].Visible = false;
                this.dataGridView9.Columns["ORNEK_KABUL"].Visible = false;
                this.dataGridView9.Columns["ORNEK_KABULEDEN"].Visible = false;
                this.dataGridView9.Columns["ORNEK_KABULTARIH"].Visible = false;
                this.dataGridView9.Columns["NUMUNE_RED"].Visible = false;
                this.dataGridView9.Columns["NUMUNE_RED_EDEN"].Visible = false;
                this.dataGridView9.Columns["NUMUNE_RED_TARIHI"].Visible = false;
                this.dataGridView9.Columns["NUMUNE_RED_ACIKLAMA"].Visible = false;
                this.dataGridView9.Columns["EKLEYEN_KULLANICI"].Visible = false;
                this.dataGridView9.Columns["LAB_TETKIK"].Visible = false;
                this.dataGridView9.Columns["HIZMET_GRUP"].Visible = false;
                this.dataGridView9.Columns["TEKNISYEN_ONAY"].Visible = false;
                this.dataGridView9.Columns["TEKNISYEN_ONAY_TARIH"].Visible = false;
                this.dataGridView9.Columns["ONAYLAYAN_TEKNİSYEN"].Visible = false;
                this.dataGridView9.Columns["UZMAN_ONAY"].Visible = false;
                this.dataGridView9.Columns["UZMAN_ONAY_TARIH"].Visible = false;
                this.dataGridView9.Columns["ONAYLAYAN_UZMAN"].Visible = false;
                this.dataGridView9.Columns["ARSIV_NO"].Visible = false;
            }
        }

        private void dataGridView9_Click(object sender, EventArgs e)
        {
            if (dataGridView9.SelectedRows.Count > 0)
            {
                textBox25.Text = dataGridView9.CurrentRow.Cells["ISLEM_NO"].Value.ToString();
                textBox26.Text = dataGridView9.CurrentRow.Cells["TCKIMLIKNO"].Value.ToString();
                textBox27.Text = dataGridView9.CurrentRow.Cells["HASTA_ADI"].Value.ToString();
                textBox28.Text = dataGridView9.CurrentRow.Cells["HASTA_SOYADI"].Value.ToString();
            }
            else
            {
                //
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (textBox29.Text == "")
            {
                MessageBox.Show("Lütfen ! Arşivlenecek Raf seçiniz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                string sorgu = "UPDATE DNA_ARSIV SET DOLULUK=@p2,ORNEK_NO=@p3,ISLEM_NO=@p4,TCKIMLIKNO=@p5,HASTA_ADI=@p6,HASTA_SOYADI=@p7 WHERE ID=@ID";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox29.Text));
                komut.Parameters.AddWithValue("@p2", "E");
                komut.Parameters.AddWithValue("@p3", textBox24.Text);
                komut.Parameters.AddWithValue("@p4", textBox25.Text);
                komut.Parameters.AddWithValue("@p5", textBox26.Text);
                komut.Parameters.AddWithValue("@p6", textBox27.Text);
                komut.Parameters.AddWithValue("@p7", textBox28.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Seçili kayıt Arşivlendi", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ArsivSorgula();
            }
        }

        private void dataGridView8_Click_1(object sender, EventArgs e)
        {
            if (dataGridView8.SelectedRows.Count > 0)
            {
                textBox29.Text = dataGridView8.CurrentRow.Cells["ID"].Value.ToString();
                textBox36.Text = dataGridView8.CurrentRow.Cells["RAF_NO"].Value.ToString();
                textBox37.Text = dataGridView8.CurrentRow.Cells["RAF_SIRA_NO"].Value.ToString();
            }
            else
            {
                //
            }
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            if (textBox29.Text == "")
            {
                MessageBox.Show("Arşivden kaldıralacak hasta seçiniz", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                string sorgu = "UPDATE DNA_ARSIV SET DOLULUK=@p2,ORNEK_NO=@p3,ISLEM_NO=@p4,TCKIMLIKNO=@p5,HASTA_ADI=@p6,HASTA_SOYADI=@p7 WHERE ID=@ID";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox29.Text));
                komut.Parameters.AddWithValue("@p2", "H");
                komut.Parameters.AddWithValue("@p3", "BOŞ");
                komut.Parameters.AddWithValue("@p4", "BOŞ");
                komut.Parameters.AddWithValue("@p5", "BOŞ");
                komut.Parameters.AddWithValue("@p6", "BOŞ");
                komut.Parameters.AddWithValue("@p7", "BOŞ");
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Seçili kayıt silindi", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ArsivSorgula();
            }
        }

        private void dataGridView8_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.Equals("E"))
                {
                    e.CellStyle.BackColor = Color.Aquamarine;
                    e.CellStyle.SelectionBackColor = Color.Aquamarine;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
                if (e.Value.Equals("H"))
                {
                    e.CellStyle.BackColor = Color.GreenYellow;
                    e.CellStyle.SelectionBackColor = Color.GreenYellow;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
            }
        }

        private void simpleButton57_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton49_Click(object sender, EventArgs e)
        {
            if (dataGridView4.RowCount > 0)
            {

                string kayit = "update LABORATUVAR_ISLEMLERI set TEKNISYEN_ONAY=@p1, TEKNISYEN_ONAY_TARIH=@p2, ONAYLAYAN_TEKNİSYEN=@p3 where TEST_ID=@p4";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@p1", "E");
                komut.Parameters.AddWithValue("@p2", dateTimePicker5.Value);
                komut.Parameters.AddWithValue("@p3", label48.Text);
                komut.Parameters.AddWithValue("@p4", textBox33.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Teknisyen onayı yapıldı", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TetkikleriListele();
            }
        }

        private void simpleButton51_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                //
            }
            else
            {
                SqlDataReader dr;
                komut = new SqlCommand("select * from TBL_PERSONEL_YETKILERI WHERE KULLANICI_ADI=@p1 AND ORNEK_TEKRAR_EDEBILIR=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", KullanıcıID.Text);
                komut.Parameters.AddWithValue("@p2", 'E');
                baglanti.Open();
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    if (dataGridView4.RowCount > 0)
                    {
                        string kayit = "update LABORATUVAR_ISLEMLERI set ORNEK_TEKRAR_VEREN=@p1, ORNEK_TEKRAR_TARIHI=@p2,TEKRAR_NEDENİ=@p3 where ISLEM_NO=@p4";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@p1", label48.Text);
                        komut.Parameters.AddWithValue("@p2", dateTimePicker5.Value);
                        komut.Parameters.AddWithValue("@p3", comboBox3.Text);
                        komut.Parameters.AddWithValue("@p4", textBox33.Text);
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Teknisyen onayı yapıldı", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TetkikleriListele();
                    }
                }
                else
                {
                    MessageBox.Show("Örneği Tekrara verme yetkiniz bulunmamaktadır.Lütfen sistem yöneticiniz ile görüşünüz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                baglanti.Close();
            }
        }

        private void simpleButton52_Click(object sender, EventArgs e)
        {
            if (dataGridView4.RowCount > 0)
            {
                string kayit = "update LABORATUVAR_ISLEMLERI set TEKNISYEN_ONAY=@p1, TEKNISYEN_ONAY_TARIH=@p2, ONAYLAYAN_TEKNİSYEN=@p3 where TEST_ID=@p4";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@p1", "H");
                komut.Parameters.AddWithValue("@p2", "  ");
                komut.Parameters.AddWithValue("@p3", "  ");
                komut.Parameters.AddWithValue("@p4", textBox33.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Teknisyen onayı kaldırıldı", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TetkikleriListele();
            }
        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Sonuç yazılacak hasta seçiniz.", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                islemno = textBox4.Text;
                testid = textBox33.Text;
                Form3_RaporlamaAraci fr3 = new Form3_RaporlamaAraci();
                fr3.textBox4.Text = islemno;
                fr3.textBox33.Text = testid;
                fr3.Show();
            }

        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            if (dataGridView4.RowCount > 0)
            {
                string kayit = "update LABORATUVAR_ISLEMLERI set UZMAN_ONAY=@p1, UZMAN_ONAY_TARIH=@p2, ONAYLAYAN_UZMAN=@p3 where TEST_ID=@p4";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@p1", "E");
                komut.Parameters.AddWithValue("@p2", dateTimePicker5.Value);
                komut.Parameters.AddWithValue("@p3", label48.Text);
                komut.Parameters.AddWithValue("@p4", textBox33.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Uzman onayı yapıldı", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TetkikleriListele();
            }
        }

        private void simpleButton53_Click(object sender, EventArgs e)
        {
            if (dataGridView4.RowCount > 0)
            {
                string kayit = "update LABORATUVAR_ISLEMLERI set UZMAN_ONAY=@p1, UZMAN_ONAY_TARIH=@p2, ONAYLAYAN_UZMAN=@p3 where TEST_ID=@p4";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@p1", "H");
                komut.Parameters.AddWithValue("@p2", "  ");
                komut.Parameters.AddWithValue("@p3", "  ");
                komut.Parameters.AddWithValue("@p4", textBox33.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Uzman Onayı Kaldırıldı", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TetkikleriListele();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                HastaResim.Image = Image.FromFile(openFileDialog1.FileName);
                resimekle = openFileDialog1.FileName.ToString();
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(resimekle, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] resim = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();


            baglanti.Open();
            string sorgu = "UPDATE HASTA_KAYIT_ISLEMLERI SET RESIM=@p2 WHERE DOSYA_NO=@DOSYANO";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@DOSYANO", Convert.ToInt32(DOSYANO.Text));
            komut.Parameters.Add("@p2", SqlDbType.Image, resim.Length).Value = resim;
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt edildi.");
        }

        void resimgoster()
        {
            if (TCKIMLIKNO.Text == "")
            {
                MessageBox.Show("Lütfen hasta seçimi yapınız.");
            }
            else
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(" SELECT RESIM FROM HASTA_KAYIT_ISLEMLERI where TCKIMLIKNO=" + TCKIMLIKNO.Text, baglanti);
                da.Fill(dt);
                dataGridView10.DataSource = dt;
                baglanti.Close();
            }
        }

        private void dataGridView10_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView10.CurrentRow.Cells["RESIM"] != null)
            {
                Stream stream = new MemoryStream((Byte[])dataGridView10.CurrentRow.Cells["RESIM"].Value);

                Image original = Image.FromStream(stream);

                HastaResim.Image = original;
            }
        }

        private void TCKIMLIKNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void DOSYANO_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            //SqlCommand cmd2 = new SqlCommand("select HASTA_ADI from TBL_MURACATKAYIT where KAYITID=@p1", baglanti);
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM LABORATUVAR_ISLEMLERI WHERE ISLEM_NO=@p1", baglanti);
            cmd2.Parameters.AddWithValue("@p1", textBox4.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
              
            }
            baglanti.Close();
        }
    }
}
