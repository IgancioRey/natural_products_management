﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Queries.GetProductsList
{
    public class ProductListVm
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
    }
}