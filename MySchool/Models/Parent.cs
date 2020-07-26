using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Parent
    {
        public int ParentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<Enfants> Enfants { get; set; }

        public ICollection<Derogation> Derogations { get; set; }
    }
}
