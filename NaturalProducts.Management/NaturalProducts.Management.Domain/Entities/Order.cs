using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; } = string.Empty;

        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("customerId")]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("customer")]
        public Customer Customer { get; set; } = default!;

        [BsonElement("paidAmount")]
        public decimal PaidAmount { get; set; }

        [BsonElement("paid")]
        public bool Paid { get; set; }

        [BsonElement("withdrawn")]
        public bool Withdrawn { get; set; }

        [BsonElement("detail")]
        public ICollection<OrderDetail>? Detail { get; set; }

    }
}
