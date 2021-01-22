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



    public partial class ParaCek : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public static string tckimlik2 = Form1.Tckimlik;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand command = new SqlCommand("Select * from banka WHERE kimlikno='" + Form1.Tckimlik + "'", connection);
        string deger;
        double bakiye;

        public ParaCek()
        {
            InitializeComponent();
          
        }
        void ParaCekme()
        {
            connection.Open();
            string sqlcommand = "UPDATE banka SET para=" + Convert.ToInt32(bakiye) + " Where kimlikno='" + tckimlik2 + "'";
            SqlCommand cmd = new SqlCommand(sqlcommand, connection);
            cmd.ExecuteNonQuery();
            lblbakiye.Text = bakiye.ToString();
            connection.Close();
            Calistir();
            MessageBox.Show("Para çekme işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            double a = 0;
            if (radioButton1.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) - 20;
                a = 20;
                ParaCekme();
            }
            if (radioButton2.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) - 50;
                a = 50;
                ParaCekme();    
            }
            if (radioButton3.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) - 200;
                a = 200;
                ParaCekme();

            }
            if (radioButton4.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) - 100;
                a = 100;
                ParaCekme();
            }

            if (radioButton5.Checked==true)
            {
             
                double degeri = Convert.ToDouble(txtCekilecek.Text);
                bakiye = Convert.ToDouble(deger) - degeri;
                a = degeri;
                ParaCekme();
                //Kayıtliİslemleer islem = new Kayıtliİslemleer();
                //islem.listBox1.Items.Add("test");
                //islem.Show();
            }

            BireyselKullanici kullanici = new BireyselKullanici();
            int kullaniciId= kullanici.KullaniciIdGetir( tckimlik2);
            kullanici.BireyselLogEkleme(kullaniciId,a +"TL"+" "+ "kadar para çekildi.");

        }
            private void button2_Click(object sender, EventArgs e)
            {
                this.Hide();
                BireyselGiris form3 = new BireyselGiris();
                form3.Show();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ParaCek_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void ParaCek_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void ParaCek_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void ParaCek_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                lblbakiye.Text = dr["para"].ToString();
                deger = dr["para"].ToString();
            }
            connection.Close();


        }
    }
    }

