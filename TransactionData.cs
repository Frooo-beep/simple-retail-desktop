using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplerRetail
{
    public class TransactionData
    {
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public int Qty { get; set; }
    }
}
