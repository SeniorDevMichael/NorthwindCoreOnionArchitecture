using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Employees.CreateEmployee
{
    public class CreateEmployeeRequest : IRequest<CreateEmployeeResponse>
    {
        //public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter LastName.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "LastName length [3,20].")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please enter FirstName.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "FirstName length [3,10].")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter Title.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Title length [3,30].")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Please enter TitleOfCourtesy.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "TitleOfCourtesy length [3,25].")]
        public string TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }


        [Required(ErrorMessage = "Please enter Address.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Address length [3,60].")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please enter City.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "City length [3,15].")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please enter Region.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Region length [3,15].")]
        public string Region { get; set; }


        [Required(ErrorMessage = "Please enter PostalCode.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "PostalCode length [3,10].")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "Please enter Country.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Country length [3,15].")]
        public string Country { get; set; }


        [Required(ErrorMessage = "Please enter HomePhone.")]
        [StringLength(24, MinimumLength = 3, ErrorMessage = "HomePhone length [3,24].")]
        public string HomePhone { get; set; }


        [Required(ErrorMessage = "Please enter Extension.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Extension length [4,4].")]
        public string Extension { get; set; }

        public byte[] Photo { get; set; }


        [Required(ErrorMessage = "Please enter Notes.")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Please enter PhotoPath.")]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "PhotoPath length [4,255].")]
        public string PhotoPath { get; set; }
    }
}