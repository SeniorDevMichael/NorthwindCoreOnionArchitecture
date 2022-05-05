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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NorthwindContext context) : base(context)
        {

        }

        public NorthwindContext NorthwindContext
        {
            get
            {
                return _context as NorthwindContext;
            }
        }

        public IEnumerable<Supplier> GetTopSuppliers(int count)
        {
            return NorthwindContext.Suppliers.Take(count);
        }
    }
}