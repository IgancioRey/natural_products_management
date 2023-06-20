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
    public class Customer: AuditableEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("lastName")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("mobileNumber")]
        public string MobileNumber { get; set; } = string.Empty;

        [BsonElement("observation")]
        public string Observation { get; set; } = string.Empty;

    }
}
