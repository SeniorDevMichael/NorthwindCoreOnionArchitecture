using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwindCore.Application.DTO.View
{
    public class ShipperDTO
    {
        public int ShipperId { get; set; }

        [Required(ErrorMessage = "Please enter CompanyName.")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "CompanyName length [2,40].")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please enter Phone.")]
        [StringLength(24, MinimumLength = 2, ErrorMessage = "Phone length [2,24].")]
        public string Phone { get; set; }

        public ShipperDTO()
        {
            Orders = new HashSet<OrderDTO>();
        }

        public ICollection<OrderDTO> Orders { get; set; }
    }
}
