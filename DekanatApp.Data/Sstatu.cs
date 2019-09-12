using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Sstatu
    {
        public Sstatu()
        {
            Students = new HashSet<Student>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
