using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Shippers.CreateShipper
{
    public class CreateShipperRequest : IRequest<CreateShipperResponse>
    {
        //public int ShipperId { get; set; }

        [Required(ErrorMessage = "Please enter CompanyName.")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "CompanyName length [2,40].")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please enter Phone.")]
        [StringLength(24, MinimumLength = 2, ErrorMessage = "Phone length [2,24].")]
        public string Phone { get; set; }
    }
}