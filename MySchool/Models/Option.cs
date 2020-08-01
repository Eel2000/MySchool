using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public class Option
    {
        [Key]
        public int OptionID { get; set; }

        [Required]
        [Display(Name ="Section")]
        public string Designation { get; set; }

        public IEnumerable<Cours> Cours { get; set; }

        public IEnumerable<Enfants> Enfants { get; set; }
    }
}