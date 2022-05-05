using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Queries.Regions.GetAllRegions
{
    public class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, IEnumerable<RegionDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRegionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionDTO>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            //return _unitOfWork.RegionRepository.GetAll().Result.Select(x => _mapper.Map<RegionDTO>(x)).ToList();
            var regions = await _unitOfWork.RegionRepository.GetAll();
            return regions.Select(x => _mapper.Map<RegionDTO>(x)).ToList();
        }
    }
}
