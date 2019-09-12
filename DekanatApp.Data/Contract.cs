using System;
using System.Collections.Generic;

namespace DekanatApp.Data
{
    public partial class Contract
    {
        public Contract()
        {
            Payments = new HashSet<Payment>();
        }

        public int ContractId { get; set; }
        public int StudentId { get; set; }
        public int ContractKindId { get; set; }
        public DateTime ContractDate { get; set; }
        public int ContractNo { get; set; }
        public decimal ContractSum { get; set; }
        public string PayerKind { get; set; }

        public Student Student { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
