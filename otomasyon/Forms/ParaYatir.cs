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
    
    public partial class ParaYatir : Form
    {
        //BireyselKullanici ac = new BireyselKullanici();
        public static string tckimlik2 = Form1.Tckimlik;
        bool move;
        int mouse_x;
        int mouse_y;
       // public static string tckimlik3 = Form1.Tckimlik;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand command = new SqlCommand("Select * from banka WHERE kimlikno='" + Form1.Tckimlik + "'", connection);
        string deger;
        double bakiye;
        public ParaYatir()
        {
            
            InitializeComponent();
            

        }
        void Message()
        {
            MessageBox.Show("Para yatırma işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        

        double a = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) + 50;
                a = 20;
                MessageBox.Show("Para yatırma işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton2.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) + 100;
                a = 50;
                MessageBox.Show("Para yatırma işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton3.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) + 200;
                a = 100;
                MessageBox.Show("Para yatırma işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton4.Checked == true)
            {
                bakiye = Convert.ToDouble(deger) + 150;
                a = 200;
                MessageBox.Show("Para yatırma işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton5.Checked == true)
            {
                double degeri = Convert.ToDouble(txtCekilecek.Text);
                bakiye = Convert.ToDouble(deger) + degeri;
                a = degeri;
                MessageBox.Show("Para yatırma işlemi başarıyla gerçekleşti. ", "Harmony Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            BireyselKullanici kullanici = new BireyselKullanici();
            int kullaniciId = kullanici.KullaniciIdGetir(tckimlik2);
            kullanici.BireyselLogEkleme(kullaniciId, a + "TL"+" "+"kadar para yatırıldı.");
            //if (bakiye < 0)
            //{
            //    DialogResult secenek = MessageBox.Show("Kredi kartına girilecek devam edilsin mi?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //    if (secenek == DialogResult.Yes)
            //    {
            //        lblbakiye.Text = bakiye.ToString();
            //    }
            //    else if (secenek == DialogResult.No)
            //    {
            //        lblbakiye.Text = "1";
            //    }
            //}

            //form.listBox1.Items.Add(a + "para yatırıldı");
            //form.label1.Text = a.ToString();


            connection.Open();
            string sqlcommand = "UPDATE banka SET para=" +Convert.ToInt32(bakiye)+" Where kimlikno='"+ tckimlik2 + "'";
            SqlCommand cmd = new SqlCommand(sqlcommand, connection);
            cmd.ExecuteNonQuery();
            lblbakiye.Text = bakiye.ToString();
            connection.Close();
            Calistir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BireyselGiris ekran = new BireyselGiris();
            ekran.Show();
        }

        private void ParaYatir_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void ParaYatir_MouseMove(object sender, MouseEventArgs e)
        {

            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void ParaYatir_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ParaYatir_Load(object sender, EventArgs e)
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
