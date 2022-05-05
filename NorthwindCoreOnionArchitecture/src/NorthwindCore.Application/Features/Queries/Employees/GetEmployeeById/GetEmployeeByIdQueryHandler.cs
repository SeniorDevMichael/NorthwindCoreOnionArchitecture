using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;//
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Queries.Employees.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            //var employee = await _unitOfWork.EmployeeRepository.GetById(request.Id);
            var employee = await _unitOfWork.EmployeeRepository.GetById(x=>x.EmployeeId==request.Id, x=>x.Orders);
            return _mapper.Map<EmployeeDTO>(employee);
        }
    }
}