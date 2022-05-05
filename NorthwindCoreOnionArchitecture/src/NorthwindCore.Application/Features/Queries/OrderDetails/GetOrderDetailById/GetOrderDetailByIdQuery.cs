using MediatR;
using NorthwindCore.Application.DTO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.OrderDetails.GetOrderDetailById
{
    public class GetOrderDetailByIdQuery : IRequest<IEnumerable<OrderDetailDTO>>
    {
        public int Id { get; set; }
    }
}