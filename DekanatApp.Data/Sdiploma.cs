using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Sdiploma
    {
        public Sdiploma()
        {
            Students = new HashSet<Student>();
        }

        public int DiplomaId { get; set; }
        public string DiplomaName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
