using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;//
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Queries.Regions.GetRegionById
{
    public class GetRegionByIdQueryHandler : IRequestHandler<GetRegionByIdQuery, RegionDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRegionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RegionDTO> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
        {
            var region = await _unitOfWork.RegionRepository.GetById(request.Id);
            return _mapper.Map<RegionDTO>(region);
        }
    }
}