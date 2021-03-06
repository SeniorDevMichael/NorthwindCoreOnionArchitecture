using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using NorthwindCore.Domain.Entities;

namespace NorthwindCore.Application.Interfaces.Repositories
{
    public interface IRegionRepository : IRepository<Region>
    {
        IEnumerable<Region> GetTopRegions(int count);
    }
}