using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Parent
    {
        [Key]
        public int ParentID { get; set; }

        [Required]
        [Display(Name ="Prenom Parent/Tuteur")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Nom Complet du parent/Tuteur")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Telephone")]
        public string Phone { get; set; }

        public ICollection<Enfants> Enfants { get; set; }

        public ICollection<Derogation> Derogations { get; set; }
    }
}
