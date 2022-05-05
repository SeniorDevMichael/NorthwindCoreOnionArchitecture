using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerResponse : CommonResponse
    {
        public int CustomerId { get; set; }
    }
}
