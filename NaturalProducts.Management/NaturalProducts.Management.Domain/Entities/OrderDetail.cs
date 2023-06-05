using NaturalProducts.Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Domain.Entities
{
    public class OrderDetail: AuditableEntity
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        [NotMapped]
        public decimal SubTotal { get { return decimal.Multiply(Count, Amount); } }
    }
}
