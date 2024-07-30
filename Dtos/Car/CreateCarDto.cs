using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_new.Dtos.Car
{
    public class CreateCarDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Brand must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Brand must be at most 50 characters long")]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Model must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Model must be at most 50 characters long")]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Price { get; set; }
        [Required]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public int Year { get; set; }
    }
}