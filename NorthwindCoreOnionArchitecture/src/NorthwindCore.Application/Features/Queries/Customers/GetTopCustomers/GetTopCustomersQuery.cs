using System.Collections.Generic;
using MediatR;
using NorthwindCore.Application.DTO.View;

namespace NorthwindCore.Application.Features.Queries.Customers.GetTopCustomers
{
    public class GetTopCustomersQuery : IRequest<IEnumerable<CustomerDTO>>
    {
        public int count { get; set; }
    }
}
