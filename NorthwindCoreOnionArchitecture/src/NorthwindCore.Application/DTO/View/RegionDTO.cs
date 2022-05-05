using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwindCore.Application.DTO.View
{
    public class RegionDTO
    {
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Please enter Region Description.")]
        public string RegionDescription { get; set; }
    }
}
