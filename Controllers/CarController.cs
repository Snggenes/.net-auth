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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_new.Controllers
{
    [Route("car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cars = await _carRepository.GetCarsAsync(query);
            var carDtos = cars.Select(car => car.ToCarDto());
            return Ok(carDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCarById([FromRoute] int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car.ToCarDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarDto createCarDto)
        {
            var car = await _carRepository.AddCarAsync(createCarDto);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car.ToCarDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] UpdateCarDto updateCarDto)
        {
            var car = await _carRepository.UpdateCarAsync(id, updateCarDto);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car.ToCarDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            var car = await _carRepository.DeleteCarAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car.ToCarDto());
        }
    }
}