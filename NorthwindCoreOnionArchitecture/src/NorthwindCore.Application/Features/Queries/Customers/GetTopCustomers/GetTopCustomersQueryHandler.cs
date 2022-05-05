using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Features.Queries.Customers.GetAllCustomers;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Customers.GetTopCustomers
{
    public class GetTopCustomersQueryHandler : IRequestHandler<GetTopCustomersQuery, IEnumerable<CustomerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetTopCustomersQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.CustomerRepository.GetTopCustomers(request.count).Select(x => _mapper.Map<CustomerDTO>(x)).ToList();
        }
    }
}
