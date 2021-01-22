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
using otomasyon.Models;

namespace otomasyon
{
    public partial class CalısanSİl : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public CalısanSİl()
        {
            InitializeComponent();
        }
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        void Listele()
        {
            dataGridView1.DataSource = KurumsalGirisTable.Listele();
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
            Listele();
            Sirketİsmi();
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            KurumsalKullanici Silme = new KurumsalKullanici();
            bool kontrol = Silme.KurumsalMusteriSilme(txtId.Text);

            if (kontrol)
            {
                System.Windows.Forms.MessageBox.Show("Çalışan Başarıyla Silindi.", "Bilgi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                Listele();
            }
            else
            {
                MessageBox.Show("Silme işlemi yapılırken beklenmedik bir hata oluştu.", "Harmony Bank");
            }

        }
        int calisanid = 0;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            KurumsalKisi kurumsalKisi = new KurumsalKisi();
            kurumsalKisi.ID = Convert.ToInt32(txtId.Text);
            kurumsalKisi.TC = textBox1.Text;
            kurumsalKisi.Ad = textBox2.Text;
            kurumsalKisi.Soyad = textBox3.Text;
            kurumsalKisi.YETKI = textBox4.Text;
            kurumsalKisi.MAAS = textBox5.Text;
            kurumsalKisi.IBAN = maskedTextBox1.Text;
            kurumsalKisi.KURUMID = comboBox1.SelectedIndex + 1;
            kurumsalKisi.CalısanGüncelle();
            MessageBox.Show("Çalışan Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CalısanSİl_Load(sender, e);
           
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalGiris kurumsalGiris = new KurumsalGiris();
            kurumsalGiris.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CalısanSİl_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void CalısanSİl_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void CalısanSİl_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void CalısanSİl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new KurumsalKisi().CalısanGetir();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            calisanid = Convert.ToInt32(row.Cells[0].Value.ToString());

            KurumsalKisi kisisi = new KurumsalKisi();
            kisisi.ID = calisanid;
            kisisi.CalisanGetirId();

            textBox1.Text = kisisi.TC;
            textBox2.Text = kisisi.Ad;
            textBox3.Text = kisisi.Soyad;
            textBox4.Text = kisisi.YETKI;
            textBox5.Text = kisisi.MAAS;
            maskedTextBox1.Text = kisisi.IBAN;
            comboBox1.SelectedIndex = kisisi.KURUMID;

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }
    }
}
