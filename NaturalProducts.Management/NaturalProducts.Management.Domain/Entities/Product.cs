﻿using NaturalProducts.Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Domain.Entities
{
    public class Product: AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }

    }
}
