using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
    {
        public int Id { get; set; }
    }
}