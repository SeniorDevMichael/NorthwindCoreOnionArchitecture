using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Orders.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            //return _unitOfWork.OrderRepository.GetAll().Result.Select(x => _mapper.Map<OrderDTO>(x)).ToList();
            var orders = await _unitOfWork.OrderRepository.GetAll();
            //var orders = await _unitOfWork.OrderRepository.GetAll(x=>x.Employee, x=>x.OrderDetails);
            return orders.Select(x => _mapper.Map<OrderDTO>(x)).ToList();
        }
    }
}
