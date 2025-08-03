using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.DTO_S
{
    public class CreateMenuItemDto
    {
        [Required, MinLength(2, ErrorMessage = "Name has to be a minimum of 2 characters")]
        public string Name { get; set; } = "";
        [MaxLength(500, ErrorMessage = "Description has to be a maximim of 500 characters")]
        public string? Description { get; set; }
        [Required]
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000")]
        public decimal Price { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Category has to be a maximum of 50 characters")]
        public string Category { get; set; } = "";
        [Url]
        public string? ImageUrl { get; set; }
    }
}
