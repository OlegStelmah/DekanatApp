using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class SpunishKind
    {
        public SpunishKind()
        {
            Violations = new HashSet<Violation>();
        }

        public int PunishKindId { get; set; }
        public string PunishKindName { get; set; }

        public ICollection<Violation> Violations { get; set; }
    }
}
