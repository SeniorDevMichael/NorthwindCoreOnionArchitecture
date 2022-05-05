using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Orders.GetTopOrders
{
    public class GetTopOrdersQueryHandler : IRequestHandler<GetTopOrdersQuery, IEnumerable<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetTopOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _unitOfWork.OrderRepository.GetTopOrders(request.count).Select(x => _mapper.Map<OrderDTO>(x)).ToList();
            return orders;
        }
    }
}