using MediatR;
using NorthwindCore.Application.DTO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Regions.GetRegionById
{
    public class GetRegionByIdQuery : IRequest<RegionDTO>
    {
        public int Id { get; set; }
    }
}