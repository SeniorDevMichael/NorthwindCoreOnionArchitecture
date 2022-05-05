using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace NorthwindCore.Application.DTO.View
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter CategoryName.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "CategoryName length [2,15].")]
        public string CategoryName { get; set; }

        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public CategoryDTO()
        {
            Products = new HashSet<ProductDTO>();
        }

        public ICollection<ProductDTO> Products { get; set; }
    }
}
