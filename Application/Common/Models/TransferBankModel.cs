using System;
using System.Collections.Generic;
using System.Text;

namespace Essensys.Application.Transfer.Commands.GetTransferCommand
{
    public class TransferModel
    {
        public int Id { get; set; }
        public float Ammount { get; set; }
        public float FinalAmmount { get; set; }
        public string SourceCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public string ExchangeCourse { get; set; }
        public string Expeditor_id { get; set; }
        public string Destinatar_id { get; set; }
        public string Status { get; set; }
        public string Iban { get; set; }
    }
}
