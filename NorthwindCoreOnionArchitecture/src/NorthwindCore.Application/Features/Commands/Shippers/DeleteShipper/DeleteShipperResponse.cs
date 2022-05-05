using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Shippers.DeleteShipper
{
    public class DeleteShipperResponse : CommonResponse
    {
        public int ShipperId { get; set; }
    }
}
