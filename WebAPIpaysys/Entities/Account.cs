namespace Payments.Entities
{

    public class Account
    {
        public int Id { get; set; }
        public long AccNum { get; set; }
        public string Product { get; set; }
        public string Info { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }
}