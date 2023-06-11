using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Domain.Common
{
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
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
