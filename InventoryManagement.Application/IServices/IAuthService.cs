using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IServices
{
    /// <summary>
    /// Interface for authentication service.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user and generates a JWT.
        /// </summary>
        /// <param name="userLoginDto">The user login details.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        Task<string> Login(UserLoginDto userLoginDto);

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userRegisterDto">The user registration details.</param>
        Task Register(UserRegisterDto userRegisterDto);
    }
}
