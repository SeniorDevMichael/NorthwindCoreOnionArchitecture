using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Suppliers.CreateSupplier
{
    public class CreateSupplierResponse : CommonResponse
    {
        public int SupplierId { get; set; }
    }
}
