using System;

namespace DekanatApp.Models
{
    public class ContractModel
    {
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }

        public int ContractId { get; set; }
        public string ContractKindName { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal ContractSum { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal PaymentSum { get; set; }
    }
}
