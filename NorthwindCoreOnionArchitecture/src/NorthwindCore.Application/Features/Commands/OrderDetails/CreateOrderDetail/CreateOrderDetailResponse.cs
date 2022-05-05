using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.OrderDetails.CreateOrderDetail
{
    public class CreateOrderDetailResponse : CommonResponse
    {
        public int OrderId { get; set; }
    }
}