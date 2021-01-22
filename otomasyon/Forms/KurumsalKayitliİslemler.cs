using otomasyon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otomasyon
{
    public partial class KurumsalKayitliİslemler : Form
    {
        public KurumsalKayitliİslemler()
        {
            InitializeComponent();
        }
        KurumsalKullanici kurumsalKullanici = new KurumsalKullanici();
        private void KurumsalKayitliİslemler_Load(object sender, EventArgs e)
        {
            foreach (var item in kurumsalKullanici.KurumsalMusteriYaptıgiIslemleriGetir("1"))
            {
                listBox1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalGiris giris = new KurumsalGiris();
            giris.Show();


        }
    }
}
