using System.Collections;
using System.Collections.Generic;

namespace MySchool.Models
{
    public class Option
    {
        public int OptionID { get; set; }

        public string Designation { get; set; }

        public IEnumerable<Cours> Cours { get; set; }
    }
}