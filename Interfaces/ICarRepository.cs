using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_new.Dtos.Car;
using dotnet_new.helpers;
using dotnet_new.Models;

namespace dotnet_new.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsAsync(QueryObject query);
        Task<Car?> GetCarByIdAsync(int id);
        Task<Car> AddCarAsync(CreateCarDto createCarDto);
        Task<Car?> UpdateCarAsync(int id, UpdateCarDto updateCarDto);
        Task<Car?> DeleteCarAsync(int id);

    }
}