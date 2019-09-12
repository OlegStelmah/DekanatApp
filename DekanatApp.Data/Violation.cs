using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Violation
    {
        public int ViolationId { get; set; }
        public int ViolationKindId { get; set; }
        public int PunishKindId { get; set; }
        public DateTime ViolationDate { get; set; }
        public int PersonId { get; set; }
        public int? OrderId { get; set; }

        public Order Order { get; set; }
        public Person Person { get; set; }
        public SpunishKind PunishKind { get; set; }
        public SviolationKind ViolationKind { get; set; }
    }
}
