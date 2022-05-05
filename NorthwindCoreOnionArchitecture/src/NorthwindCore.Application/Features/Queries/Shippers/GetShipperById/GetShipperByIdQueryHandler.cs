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

namespace NorthwindCore.Application.Features.Queries.Shippers.GetShipperById
{
    public class GetShipperByIdQueryHandler : IRequestHandler<GetShipperByIdQuery, ShipperDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetShipperByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShipperDTO> Handle(GetShipperByIdQuery request, CancellationToken cancellationToken)
        {
            //var shipper = await _unitOfWork.ShipperRepository.GetById(request.Id);
            var shipper = await _unitOfWork.ShipperRepository.GetById(x => x.ShipperId == request.Id, x => x.Orders);
            return _mapper.Map<ShipperDTO>(shipper);
        }
    }
}