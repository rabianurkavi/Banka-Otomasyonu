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
using otomasyon.DataAccess;

namespace otomasyon
{
    public partial class Form2 : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        public Form2()
        {
           
            InitializeComponent();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        public static string Musterino { get; set; }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

      

      

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*KurumSifre kurumsal = new KurumSifre();
            kurumsal.MusteriNo = txtMusteri.Text;
            kurumsal.KullaniciAdi = txtKullanici.Text;*/
           // kurumsal.Sifre = txtSifre.Text;
            //string musterino = txtMusteri.Text;
            //string kullaniciadi = txtKullanici.Text;
            //string sifre = txtSifre.Text;
            KurumsalKullanici GirisYap = new KurumsalKullanici();
            bool varmi = GirisYap.KurumsalKullaniciGirisi(txtMusteri.Text, txtKullanici.Text, txtSifre.Text);
           // bool varmi = KurumSifreTable.KullaniciVarMi(kurumsal);


            //connection.Open();
            //SqlCommand command = new SqlCommand("Select *from KurumSifre", connection);
            //SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır
            //while (reader.Read())
            //{
            //    if (musterino == reader["MusteriNo"].ToString().TrimEnd() && kullaniciadi == reader["KullaniciAdı"].ToString().TrimEnd() && sifre == reader["Sifre"].ToString().TrimEnd())//TrimEnd demek veri tabanındaki boslukları girerken görmezden gelir.
            //    {
            //        varmi = true;

            //        break;
            //    }
            //    else
            //    {
            //        varmi = false;
            //    }
            //}
            //connection.Close();
            if (varmi)
            {
                MessageBox.Show("Başarıyla giriş yaptınız.\nHoşgeldiniz...");
                this.Hide();
                Musterino = txtMusteri.Text;
                //Musterino = GirisYap.MusteriNo;
                KurumsalGiris girisekrani = new KurumsalGiris();
                girisekrani.Show();

            }
            else
            {
                MessageBox.Show("Giriş yapamadınız !", "Program",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
 }

