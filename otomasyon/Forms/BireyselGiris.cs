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
using System.Data.OleDb;
using otomasyon.DataAccess;

namespace otomasyon
{
    public partial class BireyselGiris : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand command = new SqlCommand("Select * from banka WHERE kimlikno='"+ Form1.Tckimlik + "'",connection);
        public BireyselGiris()
        {
            InitializeComponent();
            
         }                                                                            
        //public static SqlConnection connection = new SqlConnection("Data Source:LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrat*ed Security = TRUE");
        //SqlCommand command = new SqlCommand("Select * from banka");
        
        private void btnParaCek_Click(object sender, EventArgs e)
        {
  
            connection.Close();
            this.Hide();
            ParaCek form4 = new ParaCek();
            form4.Show();
          
        }

      
        private void btnHesapDetay_Click(object sender, EventArgs e)
        {
            connection.Close();
            this.Hide();
            HesapDetay form4 = new HesapDetay();
            form4.Show();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BireyselGiris_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void BireyselGiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void BireyselGiris_MouseDown(object sender, MouseEventArgs e)
        {

            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void btnParaYolla_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParaYatir yatir = new ParaYatir();
            yatir.Show();
        }

        private void btnKayıtlıİslem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kayıtliİslemleer islem = new Kayıtliİslemleer();
            islem.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParaGonder paragonder = new ParaGonder();
            paragonder.Show();
        }

        private void BireyselGiris_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                ibann.Text = "TR" + dr["iban"].ToString();
                bakiye.Text = dr["para"].ToString() + "TL";
            }
            connection.Close();
        }
    }
}
