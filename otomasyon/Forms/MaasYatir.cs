using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otomasyon
{
   
    public partial class MaasYatir : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        //SqlCommand command = new SqlCommand("Select * from calisanlarayatirilanpara", connection);
       

        public MaasYatir()
        {
            InitializeComponent();

            connection.Open();


            //SqlDataReader dr = command.ExecuteReader();
            //if (dr.Read())
            //{
                
            //    deger = dr["yatirilanpara"].ToString();
            //}


            connection.Close();
        }
        //void Calistir()
        //{
        //    connection.Open();

        //    string kayit = "SELECT * from banka where ıd=@ıd";
        //    SqlCommand komut = new SqlCommand(kayit, connection);
        //    SqlDataReader dr = command.ExecuteReader();
        //    if (dr.Read())
        //    {

        //        deger = dr["yatirilanpara"].ToString();

        //    }
        //    connection.Close();
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            string ibanı = maskedTextBox1.Text;
            //string tc = maskedTextBox2.Text;
            //string maas = textBox1.Text;
            //connection.Open();
            //string sqlcommand = "UPDATE calisanlarayatirilanpara SET yatirilanpara=" + maas + " Where calisantc=@calisantc";
            //SqlCommand cmd = new SqlCommand(sqlcommand, connection);
            //cmd.ExecuteNonQuery();

            //connection.Close();
            //Calistir();

            string tcsi = maskedTextBox2.Text;
            double maas = Convert.ToDouble(textBox1.Text);
            MessageBox.Show("Maaş Başarıyla Yatırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            listBox1.Items.Add(tcsi + " " + "çalışan tcsi ve " + ibanı + " " + "ibanına" + " " + maas + "TL" + " " + "para yatırıldı.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            KurumsalGiris giris = new KurumsalGiris();
            giris.Show();
        }

        private void MaasYatir_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void MaasYatir_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void MaasYatir_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
