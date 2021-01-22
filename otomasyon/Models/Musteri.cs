using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace otomasyon.Models
{
    //abstraction
    public abstract class Musteri:IMusteri
    {
        int bakiye;
        string  _sifre;

        public string Sifre
        {
            get { return _sifre; }
            set { _sifre = value; }
        }

        public int Bakiye
        {   
            get { return bakiye; }
            set { bakiye = value; }
        }
       
        //abstraction,override,virtual classlar
        public abstract bool KurumsalLogEkleme(int kurumid, string yaptigiislem);
        public abstract bool BireyselLogEkleme(int kullaniciid, string yaptigiislem);
        public abstract bool KurumsalKullaniciGirisi(string MusteriNo, string KullaniciAdi, string Sifre);
        public abstract bool KurumsalMusteriSilme(string ID);
        [System.Obsolete]
        public abstract bool KurumsalMusteriSilme(string ID,string MusteriNo);//polymorphism
        public abstract int KullaniciIdGetir(string TC);
        public abstract int KurumsalIdGetir(string MusteriNo);    
        public abstract List<string> KurumsalMusteriYaptıgiIslemleriGetir(string ID);
        public abstract List<string> BireyselMusteriYaptıgiIslemleriGetir(string ID);
        public virtual bool BireyselKullaniciGirisi(string TCKimlikNO, string Sifre)
        {
            return false;
        }


        //Parametreli olarak aşırı yükleme yapabiliriz.
        //public abstract bool KurumsalMusteriSilme(string ID, string AD);
        //public virtual bool BireyselKullaniciGirisi(string TCKimlikNO, string Sifre, bool Adminmi)
        //{
        //    return false;
        //}
        //public virtual bool BireyselKullaniciGirisi()
        //{
        //    return false;
        //}

        //public virtual bool BireyselKullaniciGirisi(string TCKimlik)
        //{
        //    return false;
        //}

    }

}

