using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Employees.GetTopEmployees
{
    public class GetTopEmployeesQueryHandler : IRequestHandler<GetTopEmployeesQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> Handle(GetTopEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = _unitOfWork.EmployeeRepository.GetTopEmployees(request.count).Select(x => _mapper.Map<EmployeeDTO>(x)).ToList();
            return employees;
        }
    }
}