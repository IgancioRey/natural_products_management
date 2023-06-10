﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public ObjectId ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
