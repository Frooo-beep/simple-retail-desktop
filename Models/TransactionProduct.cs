using System;
using System.Collections.Generic;

namespace SimplerRetail.Models
{
    public partial class TransactionProduct
    {
        public string TransactionProductId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string Qty { get; set; } = null!;
        public int Price { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Transaction TransactionProductNavigation { get; set; } = null!;
    }
}
