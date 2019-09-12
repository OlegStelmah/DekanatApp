using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class TeachPlan
    {
        public int TeachPlanId { get; set; }
        public int SemesterId { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int TesterId { get; set; }
        public int TestKindId { get; set; }
        public DateTime TestDate { get; set; }
        public bool? IsObligatory { get; set; }

        public Group Group { get; set; }
        public Semester Semester { get; set; }
        public Subject Subject { get; set; }
        public StestKind TestKind { get; set; }
        public Person Tester { get; set; }
    }
}
