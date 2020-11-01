using Essensys.Domain.Common;
using Essensys.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Essensys.Domain.Entities
{
   public class Transaction : AuditableEntity
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
