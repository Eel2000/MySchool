using System;

namespace MySchool.Models
{
    public class Punition
    {
        public int PunitionID { get; set; }

        public int EnfantID { get; set; }

        public string Cause { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// Navigation properties
        /// </summary>
        //public Enfants Enfants { get; set; }

    }
}