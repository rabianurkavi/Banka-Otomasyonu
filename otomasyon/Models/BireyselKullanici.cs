using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon.Models
{
    
    public class BireyselKullanici : Musteri
    {
        private string _kimlikno, _adi, _soyadi, _acilistarihi, _iban;

        public string KimlikNo
        {
            get { return _kimlikno; }
            set { _kimlikno = value; }
        }
        public string Adi
        {
            get { return _adi; }
            set { _adi = value; }
        }
        public string Soyadi
        {
            get { return _soyadi; }
            set { _soyadi = value.ToUpper(); }
        }
        public string AcilisTarihi
        {
            get { return _acilistarihi; }
            set { _acilistarihi = value; }
        }
        public string IBAN
        {
            get { return _iban; }
            set { _iban = value; }
        }
 

        public override bool BireyselKullaniciGirisi(string TCKimlikNO, string Sifre)//aşırı yükleme
        {
            bool kontrol = false;
            
            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {           
                baglanti.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM banka", baglanti);
                SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır

                while (reader.Read())
                { 
                    if (TCKimlikNO == reader["kimlikno"].ToString().TrimEnd() && Sifre == reader["sifre"].ToString().TrimEnd()) //TrimEnd demek veri tabanındaki boslukları girerken görmezden gelir.
                    {

                        kontrol = true;
                        break;
                    }
                    else
                    {
                        kontrol = false;
                    }
                    // kontrol = (TCKimlikNO == reader["kimlikno"].ToString().TrimEnd() && Sifre == reader["sifre"].ToString().TrimEnd()) ? true : false;//if ifadesinin operatörlerle kısaltılmış hali
                }
                baglanti.Close();
                        
            }
            return kontrol;
        }
        public override int KullaniciIdGetir(string TC)
        {//para çekme para yatırma para gönderme kayıtlı işlemlerine getirmek için
            int ID=0;
            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {
                baglanti.Open();
                SqlCommand command = new SqlCommand("SELECT id FROM banka WHERE  kimlikno=@kimlikno", baglanti);
                command.Parameters.AddWithValue("@kimlikno", TC);
                SqlDataReader reader = command.ExecuteReader();//tablomdaki tüm değerleri okumamız için gelen tüm veriyi sağlamaktır
                
                if(reader.Read())
                {

                    ID = Convert.ToInt32(reader["id"]);
 
                }

            }
            return ID;
        }
        public override bool BireyselLogEkleme(int kullaniciid, string yaptigiislem)
        {
            bool kontrol = false;
            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {
                baglanti.Open();
                string sqltext = "insert into Para_Loglari(kullaniciid, yaptigiislem,islemtarihi) values(@p1, @p2, @p3)";


                SqlCommand command = new SqlCommand(sqltext, baglanti);
                command.Parameters.AddWithValue("@p1", kullaniciid);
                command.Parameters.AddWithValue("@p2", yaptigiislem);
                command.Parameters.AddWithValue("@p3", DateTime.Now.ToString());

                kontrol = Convert.ToBoolean(command.ExecuteNonQuery());

            }
            return kontrol;

        }
        public override List<string> BireyselMusteriYaptıgiIslemleriGetir(string kullaniciid)
        {
            //Kayıtliİslemleer Islem = new Kayıtliİslemleer();

            using (var baglanti = VeritabaniBaglantisi.DBBaglantisi())//bellekte daha fazla yer kaplamaması için manuel olarak nesneyi dispose etmemize gerek kalmaz.
            {
                baglanti.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Para_Loglari WHERE kullaniciid = @kullaniciid", baglanti);
                command.Parameters.AddWithValue("@kullaniciid", kullaniciid);
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
                    //  System.Windows.Forms.MessageBox.Show(FullLog);
                    // Islem.listBox1.Items.Add("RABİA");
                }
    
                baglanti.Close();
                return logList;
            }
        }
        public override bool KurumsalKullaniciGirisi(string MusteriNo, string KullaniciAdi, string Sifre)
        {
            throw new NotImplementedException();
        }

        public override bool KurumsalMusteriSilme(string ID)
        {
            throw new NotImplementedException();
        }
        public override bool KurumsalLogEkleme(int kurumid, string yaptigiislem)
        {
            throw new NotImplementedException();
        }

        public override int KurumsalIdGetir(string MusteriNo)
        {
            throw new NotImplementedException();
        }

        public override List<string> KurumsalMusteriYaptıgiIslemleriGetir(string ID)
        {
            throw new NotImplementedException();
        }

        public override bool KurumsalMusteriSilme(string ID, string MusteriNo)
        {
            throw new NotImplementedException();
        }

        //public override bool BireyselKullaniciGirisi(string TCKimlikNO, string Sifre, bool Adminmi)
        //{
        //    return false;
        //}

        //public override bool KurumsalMusteriSilme(string ID)
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool KurumsalMusteriSilme(string ID, string AD)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
