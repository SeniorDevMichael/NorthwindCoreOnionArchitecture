using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Orders.CreateOrder
{
    public class CreateOrderResponse : CommonResponse
    {
        public int OrderId { get; set; }
    }
}