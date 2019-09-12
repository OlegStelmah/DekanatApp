using System;

namespace DekanatApp.Models
{
    public class TeachPlanModel
    {
        public string Faculty { get; set; }
        public string Cafedra { get; set; }
        public string Speciality { get; set; }

        public string TestKindName { get; set; }

        public string SubjectName { get; set; }
        public string SubjectShifr { get; set; }

        public DateTime TeachBegindDate { get; set; }
        public DateTime TeachEndDate { get; set; }
    }
}
