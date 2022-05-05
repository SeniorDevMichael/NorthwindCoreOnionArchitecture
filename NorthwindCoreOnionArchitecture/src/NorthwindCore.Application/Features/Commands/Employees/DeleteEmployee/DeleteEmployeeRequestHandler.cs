using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Employees.DeleteEmployee
{
    public class DeleteEmployeeRequestHandler : IRequestHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEmployeeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EmployeeRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.EmployeeRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteEmployeeResponse
                {
                    EmployeeId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteEmployeeResponse
            {
                EmployeeId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}