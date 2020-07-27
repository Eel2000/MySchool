using System;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public enum Type
    {
        Interrogation,Examen,Devoir
    }

    public class Travail
    {
        [Key]
        public int TravailID { get; set; }

        public int CoursID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        
        [Required]
        [Display(Name ="Type de travail effectuer")]
        public Type? Type { get; set; }


        /// <summary>
        /// Navigation properties
        /// </summary>
        public Cours Cours { get; set; }
    }
}