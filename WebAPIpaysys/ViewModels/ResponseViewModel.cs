using System.Collections.Generic;

namespace Payments.ViewModels
{

    public class ResponseViewModel
    {
        public int Status { get; set; }
        public string Msg { get; set; }
        public int Count { get; set; }
        public List<AccountViewModel> Accounts { get; set; }
    }
}