using System.Collections.Generic;
using MediatR;
using NorthwindCore.Application.DTO.View;

namespace NorthwindCore.Application.Features.Queries.Orders.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDTO>>
    {

    }
}