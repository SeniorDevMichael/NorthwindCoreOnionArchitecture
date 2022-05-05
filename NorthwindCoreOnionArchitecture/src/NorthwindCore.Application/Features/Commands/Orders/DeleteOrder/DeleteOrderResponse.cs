using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Orders.DeleteOrder
{
    public class DeleteOrderResponse : CommonResponse
    {
        public int OrderId { get; set; }
    }
}