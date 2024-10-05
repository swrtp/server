﻿using CarRentalSystem.Application.Bases;
using CarRentalSystem.Application.Contracts.Service;
using CarRentalSystem.Application.Request;
using CarRentalSystem.Domain.Entity;
using CarRentalSystem.Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Api.Controllers
{
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<BaseResponse<UserEntity>> Register(RegisterRequest registerRequest)
        {
            return await _userService.Register(registerRequest);
        }
        [HttpGet("user/{UserId:Guid}")]
        public async Task<IActionResult> GetUserById(Guid UserId)
        {
            var user = await _userService.GetByIdAsync(UserId);
            if (user != null)
            {
                return Ok(user);
            } else
            {
                return NotFound();
            }
        }
        [HttpPost("login")]
        public async Task<BaseResponse<LoginResponse>> Login(LoginRequest loginRequest)
        {
            return await _userService.Login(loginRequest);
        }
        [HttpPost("active/{userId:Guid}")]
        public async Task<BaseResponse<bool>> ActiveAccount(Guid userId)
        {
            return await _userService.Active(userId);
        }
    }
}