﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class TermLocate
    {
        [Key, ForeignKey("LocateId")]
        public int LocateId { get; set; }
        public virtual Locate Locate { get; set; }

        [Key, ForeignKey("TermId")]
        public int TermId { get; set; }
        public virtual Term Term { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [StringLength(50, ErrorMessage = "Value can't be longer than 50 characters")]
        public string Value { get; set; }
    }
}