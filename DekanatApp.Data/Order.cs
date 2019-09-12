using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Order
    {
        public Order()
        {
            Violations = new HashSet<Violation>();
        }

        public int OrderId { get; set; }
        public int OrderKindId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNo { get; set; }
        public string OrderText { get; set; }

        public SorderKind OrderKind { get; set; }
        public ICollection<Violation> Violations { get; set; }
    }
}
