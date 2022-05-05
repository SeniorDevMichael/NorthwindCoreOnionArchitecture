using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindCore.Application.Interfaces.Repositories;
using NorthwindCore.Domain.Entities;
using NorthwindCore.Infrastructure.Context;
using NorthwindCore.Infrastructure.Repositories.Base;

namespace NorthwindCore.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {

        }

        public NorthwindContext NorthwindContext
        {
            get
            {
                return _context as NorthwindContext;
            }
        }

        public IEnumerable<Order> GetTopOrders(int count)
        {
            return NorthwindContext.Orders.Take(count);
        }
    }
}