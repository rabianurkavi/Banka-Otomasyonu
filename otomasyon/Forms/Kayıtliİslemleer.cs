using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using otomasyon.Models;

namespace otomasyon
{
    public partial class Kayıtliİslemleer : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public Kayıtliİslemleer()
        {
            InitializeComponent();

        }
        
        //public void Kayitliİslemler()
        //{
        //    ParaYatir yazdir = new ParaYatir();
          
        //}

       
        BireyselKullanici Bireysel = new BireyselKullanici();
      
       
        private void Kayıtliİslemleer_Load(object sender, EventArgs e)
        {
            foreach (var item in Bireysel.BireyselMusteriYaptıgiIslemleriGetir("1"))
            {
                listBox1.Items.Add(item);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BireyselGiris giris = new BireyselGiris();
            giris.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Kayıtliİslemleer_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Kayıtliİslemleer_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Kayıtliİslemleer_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }
    }
}
