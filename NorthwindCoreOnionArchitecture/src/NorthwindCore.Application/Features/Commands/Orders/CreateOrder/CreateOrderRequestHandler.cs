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

namespace NorthwindCore.Application.Features.Commands.Orders.CreateOrder
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = _mapper.Map<Order>(request);

            await _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.Complete();

            return new CreateOrderResponse
            {
                OrderId = order.OrderId,
                Succeed = order != null,
                Message = "Başarıyla eklenmiştir."
            };
        }
    }
}