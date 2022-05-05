using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductResponse : CommonResponse
    {
        public int ProductId { get; set; }
    }
}
