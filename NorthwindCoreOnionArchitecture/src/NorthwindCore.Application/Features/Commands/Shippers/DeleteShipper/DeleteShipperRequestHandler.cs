using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Shippers.DeleteShipper
{
    public class DeleteShipperRequestHandler : IRequestHandler<DeleteShipperRequest, DeleteShipperResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteShipperRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteShipperResponse> Handle(DeleteShipperRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ShipperRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.ShipperRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteShipperResponse
                {
                    ShipperId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteShipperResponse
            {
                ShipperId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}