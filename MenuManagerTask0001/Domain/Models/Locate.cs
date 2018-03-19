using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Locate
    {
        [Key]
        public int LocateId { get; set; }

        [Required(ErrorMessage = "Language code is required")]
        [StringLength(2, ErrorMessage = "Language code can't be longer than 2 characters")]
        public string LanguageCode { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Native Language is required")]
        [StringLength(50, ErrorMessage = "Native Language  can't be longer than 50 characters")]
        public string NativeLanguage { get; set; }
    }
}
