using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_new.Dtos.Car;
using dotnet_new.Models;

namespace dotnet_new.Mappers
{
    public static class CarMappers
    {
        public static CarDto ToCarDto(this Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Price = car.Price,
                Year = car.Year
            };
        }

        public static Car ToCarFromCreate(this CreateCarDto createCarDto)
        {
            return new Car
            {
                Brand = createCarDto.Brand,
                Model = createCarDto.Model,
                Price = createCarDto.Price,
                Year = createCarDto.Year
            };
        }

        public static Car ToCarFromUpdate(this Car car, UpdateCarDto updateCarDto)
        {
            if (updateCarDto.Price != 0 || updateCarDto.Price != car.Price)
            {
                car.Price = updateCarDto.Price;
            }

            return car;
        }

    }
}