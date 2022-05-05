using System.Collections.Generic;
using MediatR;
using NorthwindCore.Application.DTO.View;

namespace NorthwindCore.Application.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {

    }
}