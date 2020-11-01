using Essensys.Domain.Common;
using System;

namespace Essensys.Domain.Entities
{
    public class Token:AuditableEntity
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Expired { get; set; }
        public int TransactionID { get; set; }
        public Transaction Transaction { get; set; }
    }
}
