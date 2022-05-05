using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public int Id { get; set; }
    }
}