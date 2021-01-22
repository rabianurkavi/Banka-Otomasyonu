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
using otomasyon.DataAccess;

namespace otomasyon
{
    public partial class CalısanEkle : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public CalısanEkle()
        {
            InitializeComponent();
        }
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        void Listele()
        {          
            dataGridView1.DataSource = KurumsalGirisTable.Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
            Sirketİsmi();
        }
        void Sirketİsmi()
        {
            SqlCommand komut = new SqlCommand("Select * From KurumSifre", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "KurumId";
            comboBox1.DisplayMember = "KurumsalAdı";
            comboBox1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //KurumsalKisi kisi = new KurumsalKisi();
           

            try
            {
                KurumsalKisi kisi = new KurumsalKisi();
                kisi.Ad = textBox2.Text;
                kisi.Soyad = textBox3.Text;
                kisi.TC = textBox1.Text;
                kisi.YETKI = textBox4.Text;
                kisi.MAAS = textBox5.Text;
                kisi.IBAN = maskedTextBox1.Text;
                kisi.KURUMID = comboBox1.SelectedIndex + 1;
                kisi.CalısanEkle();
                Listele();

                MessageBox.Show("Yeni çalışan başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //    //Listele();

            }
            catch (Exception ex)
            { 
            
                MessageBox.Show("Hata mesajı: "+ex.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox1.Text = "";
                maskedTextBox1.Text = "";

            }

        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalGiris kurumsalGiris = new KurumsalGiris();
            kurumsalGiris.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CalısanEkle_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void CalısanEkle_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void CalısanEkle_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }
        
        private void CalısanEkle_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource =data.
        }
    }
}
