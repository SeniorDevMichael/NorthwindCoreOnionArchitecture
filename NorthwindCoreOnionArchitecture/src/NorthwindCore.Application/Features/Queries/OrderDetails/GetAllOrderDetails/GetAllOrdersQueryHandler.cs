using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.OrderDetails.GetAllOrderDetails
{
    public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, IEnumerable<OrderDetailDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrderDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailDTO>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            //return _unitOfWork.OrderRepository.GetAll().Result.Select(x => _mapper.Map<OrderDTO>(x)).ToList();
            var order_details = await _unitOfWork.OrderDetailRepository.GetAll();
            return order_details.Select(x => _mapper.Map<OrderDetailDTO>(x)).ToList();
        }
    }
}
