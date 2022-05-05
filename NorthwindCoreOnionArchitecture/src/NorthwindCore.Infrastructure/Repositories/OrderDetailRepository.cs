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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(NorthwindContext context) : base(context)
        {

        }

        public NorthwindContext NorthwindContext
        {
            get
            {
                return _context as NorthwindContext;
            }
        }

        public IEnumerable<OrderDetail> GetTopOrderDetails(int count)
        {
            return NorthwindContext.OrderDetails.Take(count);
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int orderID)
        {
            return NorthwindContext.OrderDetails.Where(c=>c.OrderId==orderID);
        }
    }
}