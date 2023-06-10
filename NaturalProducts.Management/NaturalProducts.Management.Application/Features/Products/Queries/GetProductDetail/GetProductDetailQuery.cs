using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery: IRequest<ProductDetailVm>
    {
        public string Id { get; set; }
    }
}
