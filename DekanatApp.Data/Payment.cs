using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int ContractId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentSum { get; set; }
        public int DocumentNo { get; set; }

        public Contract Contract { get; set; }
    }
}
