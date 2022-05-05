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
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(NorthwindContext context) : base(context)
        {

        }

        public NorthwindContext NorthwindContext
        {
            get
            {
                return _context as NorthwindContext;
            }
        }

        public IEnumerable<Region> GetTopRegions(int count)
        {
            return NorthwindContext.Regions.Take(count);
        }
    }
}