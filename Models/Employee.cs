using System;
using System.Collections.Generic;

namespace SimplerRetail.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
