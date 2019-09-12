using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Speciality
    {
        public Speciality()
        {
            Groups = new HashSet<Group>();
        }

        public int SpecialityId { get; set; }
        public int CafedraId { get; set; }
        public string SpecialityName { get; set; }
        public string SpecialityShifr { get; set; }

        public Cafedra Cafedra { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
