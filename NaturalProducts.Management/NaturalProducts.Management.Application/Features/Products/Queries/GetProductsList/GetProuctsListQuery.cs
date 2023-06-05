using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Queries.GetProductsList
{
    public class GetProuctsListQuery : IRequest<List<ProductListVm>>
    {

    }
}
