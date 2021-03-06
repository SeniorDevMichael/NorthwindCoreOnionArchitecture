using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        [Required(ErrorMessage = "Please enter CompanyName.")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "CompanyName length [2,40].")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please enter ContactName.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "ContactName length [2,30].")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Please enter ContactTitle.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "ContactTitle length [2,30].")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage = "Please enter Address.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Address length [2,60].")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter City.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "City length [2,15].")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Region.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Region length [2,15].")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Please enter PostalCode.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "PostalCode length [2,10].")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter Country.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Country length [2,15].")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter Phone.")]
        [StringLength(24, MinimumLength = 2, ErrorMessage = "Phone length [2,24].")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Fax.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Fax length [1,10].")]
        public string Fax { get; set; }
    }
}
