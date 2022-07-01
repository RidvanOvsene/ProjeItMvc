using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProjeTanim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjeTanimId { get; set; }
        public string ProjeTanimAdi { get; set; }
        public int? SponsorId { get; set; }
        public int? HastaUzmanlikId { get; set; }
        public int? KanserTurId { get; set; }
        public int? MateryalTipId { get; set; }
        public int? TüpCinsId { get; set; }
    }
}
