using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_new.Dtos.Car
{
    public class UpdateCarDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Price { get; set; }
    }
}