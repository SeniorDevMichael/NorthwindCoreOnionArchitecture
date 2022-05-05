using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Orders.DeleteOrder
{
    public class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrderRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.OrderRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.OrderRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteOrderResponse
                {
                    OrderId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteOrderResponse
            {
                OrderId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}