using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Employees.CreateEmployee
{
    public class CreateEmployeeResponse : CommonResponse
    {
        public int EmployeeId { get; set; }
    }
}
