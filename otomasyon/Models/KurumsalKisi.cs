using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon
{
    public  class KurumsalKisi
    {
        private int id;
        private string kurumsalcalısanad;
        private string kurumsalcalısansoyad;
        private string kurumsalcalısantc;
        private string kurumsalcalısanyetkı;
        private string kurumsalcalısanmaas;
        private string kurumsalcalısanıban;
        private int kurumıd;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Ad
        {
            get { return kurumsalcalısanad; }
            set
            {
                kurumsalcalısanad = value.ToLower();
               
            }

        }
        public string Soyad
        {
            get { return kurumsalcalısansoyad; }
            set {
                kurumsalcalısansoyad = value.ToUpper();
                //kurumsalcalısansoyad = value;
            }

        }
        public string TC
        {
            get { return kurumsalcalısantc; }
            set { kurumsalcalısantc = value;
                ///*int s = Convert.ToInt32(value)*/;
              /*  kurumsalcalısantc = Math.Abs(s).ToString();*/  }

            }
        public string YETKI
        {
            get { return kurumsalcalısanyetkı; }
            set
            { kurumsalcalısanyetkı = value.ToUpper(); }

        }
        public string MAAS
        {
            get { return kurumsalcalısanmaas; }
            set { kurumsalcalısanmaas = value; }

        }
        public string IBAN
        {
            get { return kurumsalcalısanıban; }
            set { kurumsalcalısanıban= value; }

        }
        public int KURUMID
        {
            get { return kurumıd; }
            set { kurumıd = value; }

        }
        public KurumsalKisi()
        {
            this.id = 0;
            this.kurumsalcalısanad = "";
            this.kurumsalcalısansoyad = "";
            this.kurumsalcalısanmaas = "";
            this.kurumsalcalısantc = "";
            this.kurumsalcalısanyetkı = "";
            this.kurumsalcalısanıban = "";
            this.kurumıd = 0;
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-J3FG52P2; Initial Catalog=VeriTabani;Integrated Security=TRUE");
        SqlCommand komut;
        SqlDataReader okuyucu;
        public DataTable CalısanGetir()
        {
            komut = new SqlCommand("Select * from KurumsalSırket ", connection);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            okuyucu = komut.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(okuyucu);
            return dataTable;

        }
    
        public void CalisanGetirId()
        {
            komut = new SqlCommand("Select * from KurumsalSırket", connection);
            komut.Parameters.AddWithValue("@Id", this.id);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            okuyucu = komut.ExecuteReader(CommandBehavior.CloseConnection);
            okuyucu.Read();
            this.kurumsalcalısanad = okuyucu["KurumsalCalısanAdı"].ToString();
            this.kurumsalcalısansoyad = okuyucu["KurumsalCalısanSoyadı"].ToString();
            this.kurumsalcalısantc = okuyucu["KurumsalCalısanTc"].ToString();
            this.kurumsalcalısanyetkı = okuyucu["KurumsalCalısanYetkisi"].ToString();
            this.kurumsalcalısanmaas = okuyucu["KurumsalCalısanMaası"].ToString();
            this.kurumsalcalısanıban = okuyucu["KurumsalCalısanIbanı"].ToString();
            this.kurumıd = Convert.ToInt32(okuyucu["KurumsalId"]);
            connection.Close();
        }
            public void CalısanEkle()
            {
           
            string sqltext= "insert into KurumsalSırket(KurumsalCalısanAdı, KurumsalCalısanSoyadı, KurumsalCalısanTc, KurumsalCalısanYetkisi, KurumsalCalısanMaası, KurumsalCalısanIbanı, KurumsalId) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7)";

            komut = new SqlCommand(sqltext, connection);
            komut.Parameters.AddWithValue("@p1", this.kurumsalcalısanad);
            komut.Parameters.AddWithValue("@p2", this.kurumsalcalısansoyad);
            komut.Parameters.AddWithValue("@p3",this.kurumsalcalısantc);
            komut.Parameters.AddWithValue("@p4", this.kurumsalcalısanyetkı);
            komut.Parameters.AddWithValue("@p5", this.kurumsalcalısanmaas);
            komut.Parameters.AddWithValue("@p6", this.kurumsalcalısanıban);
            komut.Parameters.AddWithValue("@p7", this.kurumıd);
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            //System.Windows.Forms.MessageBox.Show(sqltext);
            komut.ExecuteNonQuery();
            connection.Close();
            //bakiye = Convert.ToDouble(deger) - degeri;
            //connection.Open();
            //String sqltext = "UPDATE banka SET para=" + Convert.ToInt32(bakiye) + " Where kimlikno='" + tckimlik2 + "'";
            //SqlCommand cmd = new SqlCommand(sqltext, connection);

            //cmd.ExecuteNonQuery();
            //lblbakiye.Text = bakiye.ToString();
            //connection.Close();
            //Calistir();


        }
        public void CalısanGüncelle()
        {
          
            string komutgüncelle = "Update KurumsalSırket set KurumsalCalısanAdı=@p1,KurumsalCalısanSoyadı=@p2,KurumsalCalısanTc=@p3,KurumsalCalısanYetkisi=@p4,KurumsalCalısanMaası=@p5,KurumsalCalısanIbanı=@p6,KurumsalId=@p7 where Id=@p8";
            komut = new SqlCommand(komutgüncelle, connection);
            komut.Parameters.AddWithValue("@p1", this.kurumsalcalısanad);
            komut.Parameters.AddWithValue("@p2", this.kurumsalcalısansoyad);
            komut.Parameters.AddWithValue("@p3", this.kurumsalcalısantc);
            komut.Parameters.AddWithValue("@p4", this.kurumsalcalısanyetkı);
            komut.Parameters.AddWithValue("@p5", this.kurumsalcalısanmaas);
            komut.Parameters.AddWithValue("@p6", this.kurumsalcalısanıban);
            komut.Parameters.AddWithValue("@p7", this.kurumıd);
            komut.Parameters.AddWithValue("@p8", this.id);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            //System.Windows.Forms.MessageBox.Show(komutgüncelle);
            komut.ExecuteNonQuery();
            connection.Close();
        }

    }
}
