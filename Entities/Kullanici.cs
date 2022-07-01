using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanici
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdiSoyadi { get; set; }
        public string Sifre { get; set; }
        public int? RolId { get; set; }
    }
}
