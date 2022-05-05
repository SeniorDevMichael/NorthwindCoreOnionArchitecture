using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Regions.GetTopRegions
{
    public class GetTopRegionsQuery : IRequest<IEnumerable<RegionDTO>>
    {
        public int count { get; set; }
    }
}