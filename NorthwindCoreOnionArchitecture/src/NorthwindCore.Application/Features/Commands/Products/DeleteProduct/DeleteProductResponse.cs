using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductResponse : CommonResponse
    {
        public int ProductId { get; set; }
    }
}
