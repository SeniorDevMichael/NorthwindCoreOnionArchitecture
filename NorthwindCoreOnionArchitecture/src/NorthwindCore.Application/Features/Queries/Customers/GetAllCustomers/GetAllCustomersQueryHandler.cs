using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Features.Queries.Customers.GetAllCustomers;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.GetAllCategories
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken) //OK
        {
            //return _unitOfWork.CustomerRepository.GetAll().Result.Select(x => _mapper.Map<CustomerDTO>(x)).ToList();
            var customers = await _unitOfWork.CustomerRepository.GetAll();
            return customers.Select(x => _mapper.Map<CustomerDTO>(x)).ToList();
        }
    }
}