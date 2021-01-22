using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon.Models
{
    public class KurumsalGiris
    {
        public int Id { get; set; }
        public string KurumsalCalısanAdı { get; set; }
        public string KurumsalCalısanSoyadı { get; set; }
        public string KurumsalCalısanTc { get; set; }
        public string KurumsalCalısanYetkisi { get; set; }
        public string KurumsalCalısanMaası { get; set; }
        public string KurumsalCalısanIbanı { get; set; }
        public int KurumsalId { get; set; }
    }
}
