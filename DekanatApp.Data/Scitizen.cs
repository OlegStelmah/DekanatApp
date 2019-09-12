using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Scitizen
    {
        public Scitizen()
        {
            Persons = new HashSet<Person>();
        }

        public int CitizenId { get; set; }
        public string CitizenName { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
