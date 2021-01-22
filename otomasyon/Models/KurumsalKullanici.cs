using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using otomasyon.DataAccess;

namespace otomasyon.Models
{
    //inheritance
    public class KurumsalKullanici : Musteri
    {

        string _musterino, _kullaniciadi, _kurumsaladi;

        //encapsulation
        public string MusteriNo
        {
            get { return _musterino; }
            set {
                int s = Convert.ToInt32(value); 
                  _musterino= Math.Abs(s).ToString();
                   
                 }
        }
        public string KullaniciAdi
        {
            get { return _kullaniciadi; }
            set { _kullaniciadi = value.ToLower(); }
        }
        public string KurumsalAdi
        {
            get { return _kurumsaladi; }
            set { _kurumsaladi = value.ToLower(); }
        }

        public override bool KurumsalLogEkleme(int kurumid, string yaptigiislem)
        {

            bool kontrol = false;
            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {
                baglanti.Open();
                string sqltext = "insert into Kurumsal_Para_Loglari(kurumsalid, yaptigiislem,islemtarihi) values(@p1, @p2, @p3)";


                SqlCommand command = new SqlCommand(sqltext, baglanti);
                command.Parameters.AddWithValue("@p1", kurumid);
                command.Parameters.AddWithValue("@p2", yaptigiislem);
                command.Parameters.AddWithValue("@p3", DateTime.Now.ToString());

                kontrol = Convert.ToBoolean(command.ExecuteNonQuery());

            }
            return kontrol;
        }
        public override int KurumsalIdGetir(string Musterino)
        {
            int ID = 0;
            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {

                string sqltext = "SELECT * FROM KurumSifre WHERE MusteriNo= @MusteriNo";
                SqlCommand command = new SqlCommand(sqltext, baglanti);
                baglanti.Open();
                //SqlCommand command = new SqlCommand("SELECT * FROM KurumSifre WHERE MusteriNo=@MusteriNo", baglanti);
                command.Parameters.AddWithValue("@MusteriNo", Musterino);
                //System.Windows.Forms.MessageBox.Show(sqltext);

                SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır
                
               if(reader.Read())
                {

                    ID =Convert.ToInt32(reader["KurumId"]);

                }

            }//inheritance,abstraction,polymorphism,encapsulation
            return ID;
        }
        public override List<string> KurumsalMusteriYaptıgiIslemleriGetir(string kurumsalid)
        {
            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {
                baglanti.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Kurumsal_Para_Loglari WHERE kurumsalid = @kurumsalid", baglanti);
                command.Parameters.AddWithValue("@kurumsalid", kurumsalid);
                //int count = (int)command.ExecuteScalar();
                SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır

                List<string> logList = new List<string>();
                string Log, Tarih, FullLog = "islem";
                while (reader.Read())
                {

                    Log = reader["yaptigiislem"].ToString();
                    Tarih = reader["islemtarihi"].ToString();

                    FullLog = "İşlem: " + Log + "-Tarihi:" + Tarih;
                    logList.Add(FullLog);
                }


                baglanti.Close();
                return logList;
            }
               
        }
        public override bool KurumsalKullaniciGirisi(string MusteriNo, string KullaniciAdi, string Sifre)
        {
            KurumSifre kurumSifre = new KurumSifre();
            kurumSifre.MusteriNo = MusteriNo;
            kurumSifre.KullaniciAdi = KullaniciAdi;
            kurumSifre.Sifre = Sifre;
            bool kontrol = KurumSifreTable.KullaniciVarMi(kurumSifre);        
            return kontrol;

        }


        //public override bool BireyselKullaniciGirisi()
        //{
        //    return false;
        //}




        public override bool KurumsalMusteriSilme(string ID)
        {
            bool kontrol = false;
            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {
                baglanti.Open();
                SqlCommand komutsil = new SqlCommand("Delete From KurumsalSırket where Id=@p1", baglanti);
                komutsil.Parameters.AddWithValue("@p1", ID);
                komutsil.ExecuteNonQuery();
                kontrol = true;
                baglanti.Close();
  
               
                
            }
            return kontrol;
        }

        public override bool BireyselLogEkleme(int kullaniciid, string yaptigiislem)
        {
            throw new NotImplementedException();
        }

        public override int KullaniciIdGetir(string TC)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override List<string> BireyselMusteriYaptıgiIslemleriGetir(string ID)
        {
            throw new NotImplementedException();
        }

        public override bool BireyselKullaniciGirisi(string TCKimlikNO, string Sifre)
        {
            return base.BireyselKullaniciGirisi(TCKimlikNO, Sifre);
        }

        public override bool KurumsalMusteriSilme(string ID, string MusteriNo)
        {
            throw new NotImplementedException();
        }

        //public override bool KurumsalMusteriSilme(string ID, string AD)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
