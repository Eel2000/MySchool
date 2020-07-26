using System.Collections.Generic;

namespace MySchool.Models
{
    public class Enseignant
    {
        public int EnseignantID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<Cours> Cours { get; set; }

        public int OptionID { get; set; }

        /// <summary>
        /// Navigation Properties
        /// </summary>
        public Option Option { get; set; }

    }
}