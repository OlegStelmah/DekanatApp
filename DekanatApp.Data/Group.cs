using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Group
    {
        public Group()
        {
            TeachPlans = new HashSet<TeachPlan>();
        }

        public int GroupId { get; set; }
        public int SpecialityId { get; set; }
        public string GroupCode { get; set; }
        public DateTime GroupCreatDate { get; set; }

        public Speciality Speciality { get; set; }
        public ICollection<TeachPlan> TeachPlans { get; set; }
    }
}
