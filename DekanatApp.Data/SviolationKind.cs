using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class SviolationKind
    {
        public SviolationKind()
        {
            Violations = new HashSet<Violation>();
        }

        public int ViolationKindId { get; set; }
        public string ViolationKindName { get; set; }

        public ICollection<Violation> Violations { get; set; }
    }
}
