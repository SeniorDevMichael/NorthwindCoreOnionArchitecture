using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using NorthwindCore.Domain.Entities;
using NorthwindCore.Application.Mapping;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Shippers.CreateShipper
{
    public class CreateShipperRequestHandler : IRequestHandler<CreateShipperRequest, CreateShipperResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateShipperRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateShipperResponse> Handle(CreateShipperRequest request, CancellationToken cancellationToken)
        {
            Shipper shipper = _mapper.Map<Shipper>(request);

            await _unitOfWork.ShipperRepository.Add(shipper);
            await _unitOfWork.Complete();

            return new CreateShipperResponse
            {
                ShipperId = shipper.ShipperId,
                Succeed = shipper != null,
                Message = "Created successfully."
            };
        }
    }
}