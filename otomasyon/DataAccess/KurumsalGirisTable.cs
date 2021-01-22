using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon.DataAccess
{
   public static class KurumsalGirisTable
    {
        public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        public static List<Models.KurumsalGiris> Listele()
        { 
            List <Models.KurumsalGiris> liste = new List<Models.KurumsalGiris>();

            SqlCommand command = new SqlCommand("Select * from KurumsalSırket", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır
           

            while (reader.Read())
            {
                Models.KurumsalGiris kurumsalGiris = new Models.KurumsalGiris();//models klasörün ismini belirtir.
                kurumsalGiris.Id = Convert.ToInt32(reader["Id"]);
                kurumsalGiris.KurumsalCalısanAdı = reader["KurumsalCalısanAdı"].ToString();
                kurumsalGiris.KurumsalCalısanSoyadı = reader["KurumsalCalısanSoyadı"].ToString();
                kurumsalGiris.KurumsalCalısanYetkisi = reader["KurumsalCalısanYetkisi"].ToString();
                kurumsalGiris.KurumsalCalısanIbanı = reader["KurumsalCalısanIbanı"].ToString();
                kurumsalGiris.KurumsalCalısanMaası = reader["KurumsalCalısanMaası"].ToString();
                kurumsalGiris.KurumsalCalısanTc = reader["KurumsalCalısanTc"].ToString();
                kurumsalGiris.KurumsalId =Convert.ToInt32( reader["KurumsalId"]);
                liste.Add(kurumsalGiris);


            }
            connection.Close();
            return liste;

        }
      

    }
}
