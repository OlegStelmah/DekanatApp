using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Sfinance
    {
        public Sfinance()
        {
            Students = new HashSet<Student>();
        }

        public int FinanceId { get; set; }
        public string FinanceName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
