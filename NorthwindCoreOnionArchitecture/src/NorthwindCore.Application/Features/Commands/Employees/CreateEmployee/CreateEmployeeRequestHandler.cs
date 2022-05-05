using AutoMapper;
using MediatR;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using NorthwindCore.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Employees.CreateEmployee
{
    public class CreateEmployeeRequestHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            Employee employee = _mapper.Map<Employee>(request);

            await _unitOfWork.EmployeeRepository.Add(employee);
            await _unitOfWork.Complete();

            return new CreateEmployeeResponse
            {
                EmployeeId = employee.EmployeeId,
                Succeed = employee != null,
                Message = "Created successfully."
            };
        }
    }
}