using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Regions.DeleteRegion
{
    public class DeleteRegionRequestHandler : IRequestHandler<DeleteRegionRequest, DeleteRegionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRegionRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteRegionResponse> Handle(DeleteRegionRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.RegionRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.RegionRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteRegionResponse
                {
                    RegionId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteRegionResponse
            {
                RegionId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}