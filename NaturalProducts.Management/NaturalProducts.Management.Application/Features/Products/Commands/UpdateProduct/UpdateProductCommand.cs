using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest
    {
        public string ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal SellPrice { get; set; }
    }
}
