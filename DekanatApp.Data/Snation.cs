using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Snation
    {
        public Snation()
        {
            Persons = new HashSet<Person>();
        }

        public int NationId { get; set; }
        public string NationName { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
