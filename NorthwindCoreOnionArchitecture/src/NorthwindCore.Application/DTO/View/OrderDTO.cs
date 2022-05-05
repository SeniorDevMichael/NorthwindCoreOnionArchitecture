using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwindCore.Application.DTO.View
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter CustomerId.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter EmployeeId.")]
        public int EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }

        [Required(ErrorMessage = "Please enter ShipName.")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "ShipName length [2,40].")]
        public string ShipName { get; set; }

        [Required(ErrorMessage = "Please enter ShipAddress.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "ShipAddress length [2,60].")]
        public string ShipAddress { get; set; }

        [Required(ErrorMessage = "Please enter ShipCity.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "ShipCity length [2,15].")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "Please enter ShipRegion.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "ShipRegion length [2,15].")]
        public string ShipRegion { get; set; }

        [Required(ErrorMessage = "Please enter ShipPostalCode.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "ShipPostalCode length [2,10].")]
        public string ShipPostalCode { get; set; }

        [Required(ErrorMessage = "Please enter ShipCountry.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "ShipCountry length [2,15].")]
        public string ShipCountry { get; set; }

        public OrderDTO()
        {
            OrderDetails = new HashSet<OrderDetailDTO>();
        }

        public EmployeeDTO Employee { get; set; }
        public ShipperDTO ShipViaNavigation { get; set; }

        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
