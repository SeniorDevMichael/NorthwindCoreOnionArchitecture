using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.OrderDetails.DeleteOrderDetail
{
    public class DeleteOrderDetailRequestHandler : IRequestHandler<DeleteOrderDetailRequest, DeleteOrderDetailResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrderDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteOrderDetailResponse> Handle(DeleteOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var entites = _unitOfWork.OrderDetailRepository.GetOrderDetailsByOrderID(request.OrderId);

            if (entites.Count()>0)
            {
                await _unitOfWork.OrderDetailRepository.RemoveRange(entites);
                await _unitOfWork.Complete();

                return new DeleteOrderDetailResponse
                {
                    OrderId = request.OrderId,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteOrderDetailResponse
            {
                OrderId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}