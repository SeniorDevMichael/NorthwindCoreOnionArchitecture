using System.Collections.Generic;
using MediatR;
using NorthwindCore.Application.DTO.View;

namespace NorthwindCore.Application.Features.Queries.Regions.GetAllRegions
{
    public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDTO>>
    {

    }
}