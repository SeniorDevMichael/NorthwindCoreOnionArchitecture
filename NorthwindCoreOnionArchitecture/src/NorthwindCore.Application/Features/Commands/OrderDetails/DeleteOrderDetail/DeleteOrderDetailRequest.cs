using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.OrderDetails.DeleteOrderDetail
{
    public class DeleteOrderDetailRequest : IRequest<DeleteOrderDetailResponse>
    {
        public int OrderId { get; set; }
    }
}