using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.OrderDetails.GetTopOrderDetails
{
    public class GetTopOrderDetailsQueryHandler : IRequestHandler<GetTopOrderDetailsQuery, IEnumerable<OrderDetailDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopOrderDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailDTO>> Handle(GetTopOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.OrderDetailRepository.GetTopOrderDetails(request.count).Select(x => _mapper.Map<OrderDetailDTO>(x)).ToList();
        }
    }
}