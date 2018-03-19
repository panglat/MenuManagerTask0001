using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Term
    {
        [Key]
        public int TermId { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [StringLength(50, ErrorMessage = "Value can't be longer than 50 characters")]
        public string Value { get; set; }

        [StringLength(50, ErrorMessage = "Comment  can't be longer than 50 characters")]
        public string Comment { get; set; }
    }
}
