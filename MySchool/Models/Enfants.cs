using System.Collections.Generic;

namespace MySchool.Models
{
    public enum Grade
    {
        Premiere,deuxieme,troisieme,quatrieme,cinquieme,sixieme
    }

    public class Enfants
    {
        public int EnfantID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Grade? Grade { get; set; }

        public int ParentID { get; set; }

        public int OptionID { get; set; }

        public IEnumerable<Travail> Traveaux { get; set; }

        public IEnumerable<Punition> Punitions { get; set; }



        public Option Option { get; set; }

        public Parent Parent { get; set; }

    }
}