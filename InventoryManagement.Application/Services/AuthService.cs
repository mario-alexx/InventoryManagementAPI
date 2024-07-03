using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.IServices;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    /// <summary>
    /// Service for authentication operations.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="configuration">The configuration settings.</param>
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user and generates a JWT.
        /// </summary>
        /// <param name="userLoginDto">The user login details.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(userLoginDto.Email);
            if(user == null || user.Password != userLoginDto.Password)
            {
                return null;
            }
            return GenerateJwtToken(user);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userRegisterDto">The user registration details.</param>
        public async Task Register(UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                Username = userRegisterDto.Username,
            };

            await _userRepository.AddUserAsync(user);
        }

        /// <summary>
        /// Generates a JWT for a user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A JWT token.</returns>
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
