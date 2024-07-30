using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_new.Data;
using dotnet_new.Dtos.Car;
using dotnet_new.helpers;
using dotnet_new.Interfaces;
using dotnet_new.Mappers;
using dotnet_new.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_new.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext _context;

        public CarRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Car>> GetCarsAsync(QueryObject query)
        {
            var cars = _context.Cars.AsQueryable();
            if (!string.IsNullOrEmpty(query.Brand))
            {
                cars = cars.Where(car => car.Brand.Contains(query.Brand));
            }
            if (!string.IsNullOrEmpty(query.Model))
            {
                cars = cars.Where(car => car.Model.Contains(query.Model));
            }
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("brand", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.IsDescending ? cars.OrderByDescending(car => car.Brand) : cars.OrderBy(car => car.Brand);
                }
                else if (query.SortBy.Equals("model", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.IsDescending ? cars.OrderByDescending(car => car.Model) : cars.OrderBy(car => car.Model);
                }
                else if (query.SortBy.Equals("year", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.IsDescending ? cars.OrderByDescending(car => car.Year) : cars.OrderBy(car => car.Year);
                }
                else if (query.SortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.IsDescending ? cars.OrderByDescending(car => car.Price) : cars.OrderBy(car => car.Price);
                }
            }
            cars = cars.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize);
            return await cars.ToListAsync();
        }
        public async Task<Car?> GetCarByIdAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
            if (car == null)
            {
                return null;
            }
            return car;
        }
        public async Task<Car> AddCarAsync(CreateCarDto createCarDto)
        {
            var car = createCarDto.ToCarFromCreate();
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car?> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
            if (car == null)
            {
                return null;
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car?> UpdateCarAsync(int id, UpdateCarDto updateCarDto)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
            if (car == null)
            {
                return null;
            }
            car = car.ToCarFromUpdate(updateCarDto);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}