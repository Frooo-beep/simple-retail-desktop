using System;
using System.Collections.Generic;

namespace SimplerRetail.Models
{
    public partial class Product
    {
        public Product()
        {
            TransactionProducts = new HashSet<TransactionProduct>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Stock { get; set; } = null!;
        public string SupplierId { get; set; } = null!;

        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }
    }
}
