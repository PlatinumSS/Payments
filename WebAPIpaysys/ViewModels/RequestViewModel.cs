using System;

namespace Payments.ViewModels
{

    public class RequestViewModel
    {
        public string Provid { get; set; }
        public long? ClientCode { get; set; }
        public long? ContractId { get; set; }
        public Decimal? Summa { get; set; }
        public long? Tranzid { get; set; }
        public string Key { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
    }
}