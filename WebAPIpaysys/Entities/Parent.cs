using System.Collections.Generic;

namespace Payments.Entities
{

    public class Parent
    {
        public int Id { get; set; }
        public long AccNum { get; set; }
        public string FullName { get; set; }
        public string Provid { get; set; }
        public List<Account> Children { get; set; }
    }
}