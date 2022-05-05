using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Employees.GetTopEmployees
{
    public class GetTopEmployeesQuery : IRequest<IEnumerable<EmployeeDTO>>
    {
        public int count { get; set; }
    }
}