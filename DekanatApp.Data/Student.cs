using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Student
    {
        public Student()
        {
            Contracts = new HashSet<Contract>();
        }

        public int StudentId { get; set; }
        public int FinanceId { get; set; }
        public int StatusId { get; set; }
        public int DiplomaId { get; set; }
        public int SpecializId { get; set; }
        public string BookNo { get; set; }
        public string Note { get; set; }

        public Sdiploma Diploma { get; set; }
        public Sfinance Finance { get; set; }
        public Sspecializ Specializ { get; set; }
        public Sstatu Status { get; set; }
        public Person Person { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
