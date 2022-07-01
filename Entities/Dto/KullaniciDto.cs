using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class KullaniciDto
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdiSoyadi { get; set; }
        public string Sifre { get; set; }
        public int? RolId { get; set; }
        public string RolAdi { get; set; }
    }
}
