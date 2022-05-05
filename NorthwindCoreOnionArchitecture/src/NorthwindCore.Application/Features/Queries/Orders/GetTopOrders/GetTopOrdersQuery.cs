using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Orders.GetTopOrders
{
    public class GetTopOrdersQuery : IRequest<IEnumerable<OrderDTO>>
    {
        public int count { get; set; }
    }
}