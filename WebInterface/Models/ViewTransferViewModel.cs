using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebInterface.Models
{
    public class ViewTransferViewModel
    {
        public int TransactionId { get; set; }
        public string Destinatar{ get; set; }
        public string IBAN { get; set; }
        public string SourceCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public float InnitialAmmount { get; set; }
        public float FinalAmmount { get; set; }
    }
}
