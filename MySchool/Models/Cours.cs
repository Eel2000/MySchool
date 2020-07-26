using System.Collections.Generic;

namespace MySchool.Models
{
    public enum Statu
    {
        En_cours,Terminer
    }

    public class Cours
    {
        public int CoursID { get; set; }

        public int OptionID { get; set; }

        public int EnseignantID { get; set; }

        public string DesignationCours { get; set; }

        public string VolumeHoraire { get; set; }

        public Statu? Statu { get; set; }

        public IEnumerable<Travail> Traveaux { get; set; } 

        /// <summary>
        /// navigation properties
        /// </summary>
        public Option Option { get; set; }

        public Enseignant Enseignant { get; set; }
    }
}