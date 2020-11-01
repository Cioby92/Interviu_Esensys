using Essensys.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essensys.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public int  Id { get; set; }
        public string  UserId { get; set; }
        public string IBAN { get; set; }
     
    }
}
