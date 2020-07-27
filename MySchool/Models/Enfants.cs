using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public enum Grade
    {
        Premiere,deuxieme,troisieme,quatrieme,cinquieme,sixieme
    }

    public class Enfants
    {
        [Key]
        public int EnfantID { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name ="Prenom")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name ="Noms")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Grade? Grade { get; set; }

        public int ParentID { get; set; }

        public int OptionID { get; set; }

        public IEnumerable<Travail> Traveaux { get; set; }

        public IEnumerable<Punition> Punitions { get; set; }


        /// <summary>
        /// Navigation properties
        /// </summary>
        public Option Option { get; set; }

        public Parent Parent { get; set; }

    }
}