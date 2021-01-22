using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon.Models
{
    public class VeritabaniBaglantisi
    {
        public static SqlConnection DBBaglantisi()//her yerden erişilebilir
        { //sqlconnectionın dönüş tipi bağlantıdır.
            string conn = "Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE";
            SqlConnection myConn = new SqlConnection(conn);
            return myConn;
        }   
    }
}
