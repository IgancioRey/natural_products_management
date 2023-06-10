using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ObjectId>
    {
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal SellPrice { get; set; }
        public override string ToString()
        {
            return $"Product name: {Name}; Count: {Count}; Price: {Price}; SellPrice: {SellPrice}";
        }

    }
}
