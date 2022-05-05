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
using NorthwindCore.Application.Features.Commands.OrderDetails.CreateOrderDetail;

namespace NorthwindCore.Application.Features.Commands.OrderDetails.CreateDetail
{
    public class CreateOrderDetailRequestHandler : IRequestHandler<CreateOrderDetailRequest, CreateOrderDetailResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOrderDetailResponse> Handle(CreateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            OrderDetail order_detail = _mapper.Map<OrderDetail>(request);

            await _unitOfWork.OrderDetailRepository.Add(order_detail);
            await _unitOfWork.Complete();

            return new CreateOrderDetailResponse
            {
                OrderId = order_detail.OrderId,
                Succeed = order_detail != null,
                Message = "Inserted successufully."
            };
        }
    }
}