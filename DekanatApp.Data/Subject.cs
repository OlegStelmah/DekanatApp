using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Subject
    {
        public Subject()
        {
            TeachPlans = new HashSet<TeachPlan>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectShifr { get; set; }

        public ICollection<TeachPlan> TeachPlans { get; set; }
    }
}
