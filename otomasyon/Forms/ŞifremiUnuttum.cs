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
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace otomasyon
{
    public partial class ŞifremiUnuttum : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public ŞifremiUnuttum()
        {
            InitializeComponent();
        }
        //SqlConnection baglantı=new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
            baglantı.Open();
            SqlCommand command = new SqlCommand("Select * From banka Where kimlikno='" + textBox1.Text.ToString() + "'and eposta= '" + textBox2.Text.ToString() + "'", baglantı);
            SqlDataReader oku = command.ExecuteReader();
            while(oku.Read())
            {
                try
                {
                    //    if (baglantı.State == System.Data.ConnectionState.Closed)
                    //    {
                    //        baglantı.Open();
                    //    }
                    SmtpClient smtp = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailadresi = ("harmonybankdestek@gmail.com");
                    String sifre = ("05078265165Rk.");
                    String smtpsrvr = "smtp.gmail.com";
                    String kime = (oku["eposta"].ToString());
                    String konu = ("Şifre Hatırlatma Maili(HarmonyBank)");
                    String yaz = ("Sayın," +" "+ oku["adi"].ToString() + " " + oku["soyadi"].ToString()+";" + "\n" + "Bizden" +" " + tarih +" "+"tarihinde şifre hatırlatma talebinde bulundunuz. " + "\n" + "Parolanız: " + oku["sifre"].ToString() + "\nİyi Günler Dileriz.\n-HarmonyBank Ekibi");
                    smtp.Credentials = new NetworkCredential(mailadresi, sifre);
                    smtp.Port = 587;//gmail kullandığımız için bu port numarasını kullandık.
                    smtp.Host = smtpsrvr;
                    smtp.EnableSsl = true;
                    mail.From = new MailAddress(mailadresi);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtp.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş olduğunuz bilgiler uyuşuyor.Şifreniz Mail Adresinize Gönderilmiştir.","HarmonyBank",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    
                }
               
                catch (Exception Hata)
                {
                    MessageBox.Show("Mail Gönderme Hatası!", Hata.Message,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                
            }
            baglantı.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ŞifremiUnuttum_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void ŞifremiUnuttum_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void ŞifremiUnuttum_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }
    }
}
