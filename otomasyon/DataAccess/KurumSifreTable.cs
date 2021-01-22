using otomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon.DataAccess
{
    public static class KurumSifreTable
    {
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        public static bool KullaniciVarMi(KurumSifre kurumSifre)
        {
            bool varmi = false;
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from KurumSifre", connection);
            SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır

            while (reader.Read())
            {
                if (kurumSifre.MusteriNo == reader["MusteriNo"].ToString().TrimEnd() && kurumSifre.KullaniciAdi == reader["KullaniciAdı"].ToString().TrimEnd() && kurumSifre.Sifre == reader["Sifre"].ToString().TrimEnd()) //TrimEnd demek veri tabanındaki boslukları girerken görmezden gelir.
                {
                    varmi = true;
                    break;
                }
                else
                {
                    varmi = false;
                }
            }
            connection.Close();
            return varmi;
        }
    }
}
