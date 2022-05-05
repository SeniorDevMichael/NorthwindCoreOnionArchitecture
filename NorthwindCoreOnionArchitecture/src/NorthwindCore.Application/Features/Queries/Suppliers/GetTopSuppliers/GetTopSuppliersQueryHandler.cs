using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Queries.Suppliers.GetTopSuppliers
{
    public class GetTopSuppliersQueryHandler : IRequestHandler<GetTopSuppliersQuery, IEnumerable<SupplierDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopSuppliersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDTO>> Handle(GetTopSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = _unitOfWork.SupplierRepository.GetTopSuppliers(request.count).Select(x => _mapper.Map<SupplierDTO>(x)).ToList();
            return suppliers;
        }
    }
}