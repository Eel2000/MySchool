using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public class Derogation
    {
        [Key]
        public int DerogationID { get; set; }

        public int ParentID { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(50)]
        [Display(Name ="Objet")]
        public string Obj { get; set; }

        [Required]
        [MinLength(5),MaxLength(20)]
        public string Libele { get; set; }

        /// <summary>
        /// Navigation properties
        /// </summary>
        public Parent Parent { get; set; }
    }
}