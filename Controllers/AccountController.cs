using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_new.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using dotnet_new.Dtos.Account;
using dotnet_new.Interfaces;

namespace dotnet_new.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
                if (existingUser != null)
                {
                    return BadRequest("User with this email already exists");
                }

                var newUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var result = await _userManager.CreateAsync(newUser, registerDto.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                var userRole = await _userManager.AddToRoleAsync(newUser, "User");
                if (!userRole.Succeeded)
                {
                    return BadRequest(userRole.Errors);
                }

                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    return BadRequest("Invalid email or password");
                }

                var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!result)
                {
                    return BadRequest("Invalid email or password");
                }

                var token = _tokenService.CreateToken(user);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(7)
                };

                Response.Cookies.Append("Authorization", token, cookieOptions);

                return Ok(new { message = "Login successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}