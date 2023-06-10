using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NaturalProducts.Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Domain.Entities
{
    public class Product: AuditableEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ProductId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("count")]
        public int Count { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("salePrice")]
        public decimal SalePrice { get; set; }

    }
}
