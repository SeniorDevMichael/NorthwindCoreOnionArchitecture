using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;//
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Queries.Suppliers.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            //var supplier = await _unitOfWork.SupplierRepository.GetById(request.Id);
            var supplier = await _unitOfWork.SupplierRepository.GetById(x=>x.SupplierId==request.Id, x=>x.Products);
            return _mapper.Map<SupplierDTO>(supplier);
        }
    }
}