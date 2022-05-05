using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Regions.GetTopRegions
{
    public class GetTopRegionsQueryHandler : IRequestHandler<GetTopRegionsQuery, IEnumerable<RegionDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopRegionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionDTO>> Handle(GetTopRegionsQuery request, CancellationToken cancellationToken)
        {
            var regions = _unitOfWork.RegionRepository.GetTopRegions(request.count).Select(x => _mapper.Map<RegionDTO>(x)).ToList();
            return regions;
        }
    }
}