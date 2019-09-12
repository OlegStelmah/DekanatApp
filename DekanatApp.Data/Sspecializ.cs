using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Sspecializ
    {
        public Sspecializ()
        {
            Students = new HashSet<Student>();
        }

        public int SpecializId { get; set; }
        public string SpecializName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
