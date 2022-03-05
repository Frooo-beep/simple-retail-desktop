using System;
using System.Collections.Generic;

namespace SimplerRetail.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionProducts = new HashSet<TransactionProduct>();
        }

        public string Id { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string Employee { get; set; } = null!;

        public virtual Employee EmployeeNavigation { get; set; } = null!;
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }
    }
}
