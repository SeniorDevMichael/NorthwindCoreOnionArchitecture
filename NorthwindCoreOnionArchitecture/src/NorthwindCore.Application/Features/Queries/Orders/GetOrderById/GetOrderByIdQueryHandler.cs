using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;//
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Queries.Orders.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            //var order = await _unitOfWork.OrderRepository.GetById(request.Id);
            var order = await _unitOfWork.OrderRepository.GetById(x=>x.OrderId==request.Id, x=>x.Employee,x=>x.ShipViaNavigation,  x=>x.OrderDetails);
            return _mapper.Map<OrderDTO>(order);
        }
    }
}