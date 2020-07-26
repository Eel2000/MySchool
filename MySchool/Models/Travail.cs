using System;

namespace MySchool.Models
{
    public enum Type
    {
        Interrogation,Examen,Devoir
    }

    public class Travail
    {
        public int TravailID { get; set; }

        public int CoursID { get; set; }

        public DateTime Date { get; set; }

        public Type? Type { get; set; }


        /// <summary>
        /// Navigation properties
        /// </summary>
        public Cours Cours { get; set; }
    }
}