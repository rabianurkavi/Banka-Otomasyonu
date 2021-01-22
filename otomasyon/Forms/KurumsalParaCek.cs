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
using otomasyon.Models;

namespace otomasyon
{
    public partial class KurumsalParaCek : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public static string musterino2 = Form2.Musterino;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand command = new SqlCommand("Select * from KurumSifre WHERE MusteriNo='" + Form2.Musterino + "'", connection);
        string deger;
        double bakiye;
        public KurumsalParaCek()
        {
            InitializeComponent();
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                lblBakiye.Text = dr["Bakiye"].ToString();
                deger = dr["Bakiye"].ToString();
            }
            
            connection.Close();

        }
        void Calistir()
        {
            connection.Open();

            string kayit = "SELECT * from KurumSifre where MusteriNo =" + musterino2 + "";
            SqlCommand komut = new SqlCommand(kayit, connection);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                deger = dr["Bakiye"].ToString();
               
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double degeri = Convert.ToDouble(txtBakiye.Text);
            //bakiye = Convert.ToDouble(deger) - degeri;
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(" UPDATE KurumSifre SET Bakiye = " + Convert.ToInt32(bakiye) + " Where MusteriNo =" + musterino2 + "", connection);
            //cmd.ExecuteNonQuery();
            //lblBakiye.Text = bakiye.ToString();
            //connection.Close();
            //Calistir();          
            double degeri = Convert.ToDouble(txtBakiye.Text);
            bakiye = Convert.ToDouble(deger) - degeri;
            connection.Open();
            String sqltext = "UPDATE KurumSifre SET Bakiye=" + Convert.ToInt32(bakiye) + " Where MusteriNo='" +musterino2 + "'";
            SqlCommand cmd = new SqlCommand(sqltext, connection);
            cmd.ExecuteNonQuery();
            lblBakiye.Text = bakiye.ToString();
            connection.Close();
            Calistir();
            KurumsalKullanici kullanici = new KurumsalKullanici();
            int kullaniciId = kullanici.KurumsalIdGetir(musterino2);
            kullanici.KurumsalLogEkleme(kullaniciId, degeri + "TL" + " " + "kadar para çekildi.");
        }

        private void KurumsalParaCek_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void KurumsalParaCek_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void KurumsalParaCek_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalGiris giris = new KurumsalGiris();
            giris.Show();
        }
    }
}
