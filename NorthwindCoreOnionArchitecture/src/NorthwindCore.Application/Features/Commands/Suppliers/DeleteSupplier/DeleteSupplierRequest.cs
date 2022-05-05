using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Suppliers.DeleteSupplier
{
    public class DeleteSupplierRequest : IRequest<DeleteSupplierResponse>
    {
        public int Id { get; set; }
    }
}