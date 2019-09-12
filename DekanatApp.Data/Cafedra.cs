using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Cafedra
    {
        public Cafedra()
        {
            Specialities = new HashSet<Speciality>();
        }

        public int CafedraId { get; set; }
        public int FacultyId { get; set; }
        public string CafedraName { get; set; }
        public string CafedraShifr { get; set; }

        public Faculty Faculty { get; set; }
        public ICollection<Speciality> Specialities { get; set; }
    }
}
