using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Employees.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            //return _unitOfWork.EmployeeRepository.GetAll().Result.Select(x => _mapper.Map<EmployeeDTO>(x)).ToList();
            
            //var employees = await _unitOfWork.EmployeeRepository.GetAll();
            var employees = await _unitOfWork.EmployeeRepository.GetAll(x => x.Orders);
            return employees.Select(x => _mapper.Map<EmployeeDTO>(x)).ToList();
        }
    }
}
