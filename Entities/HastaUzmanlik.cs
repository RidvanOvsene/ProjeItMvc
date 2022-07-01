using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HastaUzmanlik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HastaUzmanlikId { get; set; }
        public string HastaUzmanlikAdi { get; set; }   
    }
}
