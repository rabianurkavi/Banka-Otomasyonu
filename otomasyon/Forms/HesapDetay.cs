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
    public partial class HesapDetay : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand command = new SqlCommand("Select * from banka WHERE kimlikno='" + Form1.Tckimlik + "'", connection);
        public HesapDetay()
        {
            InitializeComponent();
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                lblbakiye.Text = dr["para"].ToString();
                lbladi.Text =  dr["adi"].ToString();
                lblsoyadi.Text = dr["soyadi"].ToString() ;
                lbltckimlik.Text = dr["kimlikno"].ToString() ;
                lbliban.Text ="TR"+" "+ dr["iban"].ToString() ;
                lblacılıs.Text = dr["acilistarihi"].ToString() ;
               


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }


        private void button2_Click(object sender, EventArgs e)
        {
            connection.Close();
            this.Hide();
            BireyselGiris form3 = new BireyselGiris();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HesapDetay_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void HesapDetay_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void HesapDetay_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void HesapDetay_Load(object sender, EventArgs e)
        {

        }
    }
}
