using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchool.Models
{
    public enum Statu
    {
        En_cours,Terminer
    }

    public class Cours
    {
        [Key]
        public int CoursID { get; set; }

        //[ForeignKey(name: "OptionID")]
        public int OptionID { get; set; }

        //[ForeignKey(name: "EnseignantID")]
        public int EnseignantID { get; set; }

        [Required]
        [MinLength(10),MaxLength(30)]
        [Display(Name ="Nom du cours")]
        public string DesignationCours { get; set; }

        [Required]
        [MinLength(2),MaxLength(5)]
        [Display(Name ="Volume Horaire")]
        public string VolumeHoraire { get; set; }

        [Required]
        public Statu? Statu { get; set; }

        public IEnumerable<Travail> Traveaux { get; set; } 

        /// <summary>
        /// navigation properties
        /// </summary>
        public Option Option { get; set; }

        public Enseignant Enseignant { get; set; }
    }
}