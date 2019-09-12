using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Semester
    {
        public Semester()
        {
            TeachPlans = new HashSet<TeachPlan>();
        }

        public int SemesterId { get; set; }
        public DateTime TeachBeginDate { get; set; }
        public DateTime TeachEndDate { get; set; }
        public DateTime SessionBeginDate { get; set; }
        public DateTime SessionEndDate { get; set; }
        public DateTime Attest1Date { get; set; }
        public DateTime Attest2Date { get; set; }

        public ICollection<TeachPlan> TeachPlans { get; set; }
    }
}
