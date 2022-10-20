using System;

namespace Payments.Entities
{

    public class Payment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public long TranzId { get; set; }
        public Decimal? Summa { get; set; }
        public long ContractId { get; set; }

    }
}