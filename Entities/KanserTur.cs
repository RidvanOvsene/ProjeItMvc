﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class KanserTur
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KanserTurId { get; set; }
        public string KanserTurAdi { get; set; }    
    }
}
