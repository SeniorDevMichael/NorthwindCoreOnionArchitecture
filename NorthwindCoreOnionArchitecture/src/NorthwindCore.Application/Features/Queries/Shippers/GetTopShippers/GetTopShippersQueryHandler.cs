using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Shippers.GetTopShippers
{
    public class GetTopShippersQueryHandler : IRequestHandler<GetTopShippersQuery, IEnumerable<ShipperDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopShippersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipperDTO>> Handle(GetTopShippersQuery request, CancellationToken cancellationToken)
        {
            var shippers = _unitOfWork.ShipperRepository.GetTopShippers(request.count).Select(x => _mapper.Map<ShipperDTO>(x)).ToList();
            return shippers;
        }
    }
}