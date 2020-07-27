using System;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public class Punition
    {
        [Key]
        public int PunitionID { get; set; }

        public int EnfantID { get; set; }

        [Required]
        [MinLength(15)]
        public string Cause { get; set; }

        [Required]
        [Display(Name ="Punition")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Navigation properties
        /// </summary>
        public Enfants Enfants { get; set; }

    }
}