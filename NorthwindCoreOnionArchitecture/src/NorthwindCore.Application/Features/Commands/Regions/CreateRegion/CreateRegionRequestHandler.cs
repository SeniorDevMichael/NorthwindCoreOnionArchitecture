using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using NorthwindCore.Domain.Entities;

namespace NorthwindCore.Application.Features.Commands.Regions.CreateRegion
{
    public class CreateRegionRequestHandler : IRequestHandler<CreateRegionRequest, CreateRegionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRegionRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateRegionResponse> Handle(CreateRegionRequest request, CancellationToken cancellationToken)
        {
            Region region = _mapper.Map<Region>(request);

            await _unitOfWork.RegionRepository.Add(region);
            await _unitOfWork.Complete();

            return new CreateRegionResponse
            {
                RegionId = region.RegionId,
                Succeed = region != null,
                Message = "Başarıyla eklenmiştir."
            };
        }
    }
}
