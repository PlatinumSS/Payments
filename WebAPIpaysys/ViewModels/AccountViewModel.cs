using System.Xml.Serialization;

namespace Payments.ViewModels
{

    public class AccountViewModel
    {
        [XmlAttribute]
        public int Id { get; set; }
        public long AccNum { get; set; }
        public string Product { get; set; }
        public string Info { get; set; }
    }
}