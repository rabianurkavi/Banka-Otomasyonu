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

namespace otomasyon
{
    public partial class KurumsalGiris : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        string deger;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand command = new SqlCommand("Select * from KurumSifre WHERE MusteriNo='" + Form2.Musterino + "'", connection);
        public KurumsalGiris()
        {
            InitializeComponent();
            connection.Open();
    
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                lblBakiye.Text = dr["Bakiye"].ToString()+"TL";
                deger = dr["Bakiye"].ToString();
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalısanEkle ekle = new CalısanEkle();
            ekle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalısanSİl sil = new CalısanSİl();
            sil.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaasYatir maasyatir = new MaasYatir();
            maasyatir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalParaCek kurumsalParaCek = new KurumsalParaCek();
            kurumsalParaCek.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KurumsalGiris_Load(object sender, EventArgs e)
        {

        }

        private void KurumsalGiris_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void KurumsalGiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void KurumsalGiris_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalGirisParaYatir paraYatir = new KurumsalGirisParaYatir();
            paraYatir.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalKayitliİslemler islem = new KurumsalKayitliİslemler();
            islem.Show();
        }
    }
}
