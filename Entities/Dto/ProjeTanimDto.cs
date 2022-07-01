using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class ProjeTanimDto
    {
        public int ProjeTanimId { get; set; }
        public string ProjeTanimAdi { get; set; }
        public int? SponsorId { get; set; }
        public string SponsorAdi { get; set; }
        public int? HastaUzmanlikId { get; set; }
        public string HastaUzmanlikAdi { get; set; }
        public int? KanserTurId { get; set; }
        public string KanserTurAdi { get; set; }
        public int? MateryalTipId { get; set; }
        public string MateryalTipAdi { get; set; }
        public int? TüpCinsId { get; set; }
        public string TüpCinsAdi { get; set; }
    }
}
