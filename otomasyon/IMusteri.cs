using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon
{
   public interface IMusteri
    {
        bool KurumsalMusteriSilme(string ID);
        int KullaniciIdGetir(string TC);
        int KurumsalIdGetir(string MusteriNo);
    }
}
