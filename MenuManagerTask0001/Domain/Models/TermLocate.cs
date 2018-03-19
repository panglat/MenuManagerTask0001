using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class TermLocate
    {
        public int? LocateId { get; set; }
        [ForeignKey("LocateId")]
        public virtual Locate Locate { get; set; }

        public int? TermId { get; set; }
        [ForeignKey("TermId")]
        public virtual Term Term { get; set; }
    }
}
