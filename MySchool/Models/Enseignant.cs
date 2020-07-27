using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public class Enseignant
    {
        [Key]
        public int EnseignantID { get; set; }

        [Required]
        [Display(Name ="Prenom Enseignant")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Nom Complet")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name ="Telephone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public IEnumerable<Cours> Cours { get; set; }

        public int OptionID { get; set; }

        /// <summary>
        /// Navigation Properties
        /// </summary>
        public Option Option { get; set; }

    }
}