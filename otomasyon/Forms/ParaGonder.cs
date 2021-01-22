using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using otomasyon.Models;

namespace otomasyon
{
    public partial class ParaGonder : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        string deger;
        double bakiye;
        public static string tckimlik2 = Form1.Tckimlik;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand command = new SqlCommand("Select * from banka WHERE kimlikno='" + Form1.Tckimlik + "'", connection);
        public ParaGonder()
        {
            InitializeComponent();
        }
        void label()
        {
            lbl_sonuc.Visible = false;
        }


        private void txtKontrolEt_Click(object sender, EventArgs e)
        {
            Regex visaRegex = new Regex("^4[0-9]{12}(?:[0-9]{3})?$");
            Regex masterRegex = new Regex("^5[1-5][0-9]{14}$");
            Regex expressRegex = new Regex("^3[47][0-9]{13}$");
            Regex dinersRegex = new Regex("^3(?:0[0-5]|[68][0-9])[0-9]{11}$");
            Regex discoverRegex = new Regex("^6(?:011|5[0-9]{2})[0-9]{12}$");
            Regex jcbRegex = new Regex("^(?:2131|1800|35\\d{3})\\d{11}$");
            
            lbl_sonuc.Visible = true;



            if (visaRegex.IsMatch(msktxtiban.Text))
                lbl_sonuc.Text = "VISA'DIR 2TL KESİM OLACAKTIR";
            else if (masterRegex.IsMatch(msktxtiban.Text))
                lbl_sonuc.Text = "MASTERCARD'DIR 2TL KESİM OLACAKTIR";
            else if (expressRegex.IsMatch(msktxtiban.Text))
                lbl_sonuc.Text = "AEXPRESS'DIR 1.65TL KESİM OLACAKTIR";
            else if (dinersRegex.IsMatch(msktxtiban.Text))
                lbl_sonuc.Text = "DINERS'DIR 1.65TL KESİM OLACAKTIR";
            else if (discoverRegex.IsMatch(msktxtiban.Text))
                lbl_sonuc.Text = "DISCOVERS'DIR 1.74 TL KESİM OLACAKTIR";
            else if (jcbRegex.IsMatch(msktxtiban.Text))
                lbl_sonuc.Text = "JCB'DIR 1.45TL KESİM OLACAKTIR";
            else
                lbl_sonuc.Text = "Bilinmiyor";
        }
        void Calistir()
        {
            connection.Open();

            string kayit = "SELECT * from banka where kimlikno=" + tckimlik2 + "";
            SqlCommand komut = new SqlCommand(kayit, connection);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                deger = dr["para"].ToString();
                lblbakiye.Text = dr["para"].ToString();
            }
            connection.Close();
        }
        private void btnParaCek_Click(object sender, EventArgs e)
        {
            
            double degeri = Convert.ToDouble(txtGonderilecek.Text);
            if (msktxtiban.Text=="")
            {
                MessageBox.Show("Lütfen iban girin! " ,"Dikkat");
                bakiye = Convert.ToDouble(deger) + degeri;
                connection.Open();
                String sqltexxt = "UPDATE banka SET para=" + Convert.ToInt32(bakiye) + " Where kimlikno='" + tckimlik2 + "'";
                SqlCommand cmxd = new SqlCommand(sqltexxt, connection);

                cmxd.ExecuteNonQuery();
                lblbakiye.Text = bakiye.ToString();
                connection.Close();
                Calistir();

            }
            
            BireyselKullanici kullanici = new BireyselKullanici();
            int kullaniciId = kullanici.KullaniciIdGetir(tckimlik2);
            kullanici.BireyselLogEkleme(kullaniciId, degeri + "TL" + " " + "kadar para gönderildi.");
            bakiye = Convert.ToDouble(deger) - degeri;
            connection.Open();
            String sqltext = "UPDATE banka SET para=" + Convert.ToInt32(bakiye) + " Where kimlikno='" + tckimlik2 + "'";
            SqlCommand cmd = new SqlCommand(sqltext, connection);

            cmd.ExecuteNonQuery();
            lblbakiye.Text = bakiye.ToString();
            connection.Close();
            Calistir();
            MessageBox.Show("Para gönderme işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BireyselGiris giris = new BireyselGiris();
            giris.Show();
        }

        private void ParaGonder_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                lblbakiye.Text = dr["para"].ToString();
                deger = dr["para"].ToString();
            }
            label();
            connection.Close();
        }

        private void ParaGonder_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void ParaGonder_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void ParaGonder_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
