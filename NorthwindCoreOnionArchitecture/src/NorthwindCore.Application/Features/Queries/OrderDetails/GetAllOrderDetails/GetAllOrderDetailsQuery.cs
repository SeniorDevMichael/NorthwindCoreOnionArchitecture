using System.Collections.Generic;
using MediatR;
using NorthwindCore.Application.DTO.View;

namespace NorthwindCore.Application.Features.Queries.OrderDetails.GetAllOrderDetails
{
    public class GetAllOrderDetailsQuery : IRequest<IEnumerable<OrderDetailDTO>>
    {

    }
}