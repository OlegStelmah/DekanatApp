using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Person
    {
        public Person()
        {
            TeachPlans = new HashSet<TeachPlan>();
            Violations = new HashSet<Violation>();
        }

        public int PersonId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string BirthPlace { get; set; }
        public string Address { get; set; }
        public string Telephon { get; set; }
        public int? NationId { get; set; }
        public int? CitizenId { get; set; }
        public int? SocialId { get; set; }
        public int? StudentId { get; set; }

        public Scitizen Citizen { get; set; }
        public Snation Nation { get; set; }
        public Ssocial Social { get; set; }
        public Student Student { get; set; }
        public ICollection<TeachPlan> TeachPlans { get; set; }
        public ICollection<Violation> Violations { get; set; }
    }
}
