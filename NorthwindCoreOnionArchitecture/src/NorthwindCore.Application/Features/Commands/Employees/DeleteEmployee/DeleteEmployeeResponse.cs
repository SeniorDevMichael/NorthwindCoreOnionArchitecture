using NorthwindCore.Application.Helpers;

namespace NorthwindCore.Application.Features.Commands.Employees.DeleteEmployee
{
    public class DeleteEmployeeResponse : CommonResponse
    {
        public int EmployeeId { get; set; }
    }
}
