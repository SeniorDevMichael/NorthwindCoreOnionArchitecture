using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Shippers.GetAllShippers
{
    public class GetAllShippersQueryHandler : IRequestHandler<GetAllShippersQuery, IEnumerable<ShipperDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllShippersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipperDTO>> Handle(GetAllShippersQuery request, CancellationToken cancellationToken)
        {
            //return _unitOfWork.ShipperRepository.GetAll().Result.Select(x => _mapper.Map<ShipperDTO>(x)).ToList();

            //var shippers = await _unitOfWork.ShipperRepository.GetAll();
            var shippers = await _unitOfWork.ShipperRepository.GetAll(x=>x.Orders);
            return shippers.Select(x => _mapper.Map<ShipperDTO>(x)).ToList();
        }
    }
}
