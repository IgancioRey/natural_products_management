using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Domain.Common
{
    public class AuditableEntity
    {
        [BsonElement("createdBy")]
        public string? CreatedBy { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("lastModifiedBy")]
        public string? LastModifiedBy { get; set; }

        [BsonElement("lastModifiedDate")]
        public DateTime? LastModifiedDate { get; set; }
        public void OnCreating()
        {
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
        }

        public void OnUpdating()
        {
            LastModifiedDate = DateTime.Now;
        }
    }
}
