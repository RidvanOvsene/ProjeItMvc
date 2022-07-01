﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TüpCins
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TüpCinsId { get; set; }
        public string TüpCinsAdi { get; set; }
    }
}
