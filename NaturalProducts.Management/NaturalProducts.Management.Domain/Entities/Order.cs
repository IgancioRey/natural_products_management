using NaturalProducts.Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Domain.Entities
{
    public class Order: AuditableEntity
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public decimal PaidAmount { get; set; }
        public bool Paid { get; set; }
        public bool Withdrawn { get; set; }
        public ICollection<OrderDetail> Detail { get; set; } = default!;

    }
}
