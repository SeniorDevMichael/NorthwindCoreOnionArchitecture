using System.Collections.Generic;
using MediatR;
using NorthwindCore.Application.DTO.View;

namespace NorthwindCore.Application.Features.Queries.Shippers.GetAllShippers
{
    public class GetAllShippersQuery : IRequest<IEnumerable<ShipperDTO>>
    {

    }
}