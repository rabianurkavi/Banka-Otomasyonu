using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using otomasyon.DataAccess;
using otomasyon.Models;

namespace otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
          
            InitializeComponent();
            
        }
        bool move;
        int mouse_x;
        int mouse_y;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp_1(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        void Rabia()
        {

        }
        public static string Tckimlik { get; set; }
       

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        #region Uygulamayı Kapatma
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        
        #region Bireysel Kullanıcı Giriş Yapma Butonu
        private void button3_Click_1(object sender, EventArgs e)
        {
            BireyselKullanici Giris = new BireyselKullanici();
            
            bool varmi = Giris.BireyselKullaniciGirisi(textBox1.Text, textBox2.Text);

            if (varmi)
            {          
                MessageBox.Show("Başarıyla giriş yaptınız.\nHoşgeldiniz...", "Harmony Bank", MessageBoxButtons.OK,MessageBoxIcon.Information);
                Tckimlik = textBox1.Text;
                BireyselGiris form3 = new BireyselGiris();
                form3.Show();
                this.Hide();
            }
            else
            {
               
                MessageBox.Show("Hatalı giriş yaptınız!", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ŞifremiUnuttum unuttum = new ŞifremiUnuttum();
            unuttum.Show();

        }
    }
}

/* ARŞİVİM
             //Banka bankaa = new Banka(); 
            //bankaa.kimlikno = textBox1.Text;
            //bankaa.sifre = textBox2.Text;
            //bool varmi = BankaTable.KullaniciVarMi(bankaa);
            


            //connection.Open();
            //SqlCommand command = new SqlCommand("Select *from banka", connection);
            //SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır

            //while (reader.Read())
            //{
            //    if (kimlikno == reader["kimlikno"].ToString().TrimEnd() && sifre == reader["sifre"].ToString().TrimEnd()) //TrimEnd demek veri tabanındaki boslukları girerken görmezden gelir.
            //    {
            //        varmi = true;
            //        break;
            //    }
            //    else
            //    {
            //        varmi = false;
            //    }
            //}
            //connection.Close(); çıkış yapıp kapatıp tekrar açmam lazım




 */
