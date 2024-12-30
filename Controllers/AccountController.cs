﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using share_a_plate_backend.DTOs;
using share_a_plate_backend.Interfaces;

namespace share_a_plate_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            // constructor for account controller
            _userService = userService;

            // inject mapper into controller 
            _mapper = mapper;
        }


        // POST: api/Account/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            System.Console.WriteLine("Login");
            try
            {
                var user = await _userService.Login(loginDto);
                if (user == null)
                {
                    return Unauthorized("Invalid credentials.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Account/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            System.Console.WriteLine("Register");
            try
            {
                var user = await _userService.Register(registerDto);
                if (user == null)
                {
                    return BadRequest("User already exists.");
                }
                // return the registered user
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
