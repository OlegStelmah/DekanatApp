using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class SorderKind
    {
        public SorderKind()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderKindId { get; set; }
        public string OrderKindName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
