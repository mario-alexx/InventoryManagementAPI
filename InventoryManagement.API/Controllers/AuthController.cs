using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    /// <summary>
    /// Controller for authentication.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userRegisterDto">The user registration details.</param>
        /// <returns>An action result.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            await _authService.Register(userRegisterDto);
            return Ok();
        }

        /// <summary>
        /// Authenticates a user and generates a JWT.
        /// </summary>
        /// <param name="userLoginDto">The user login details.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var token = await _authService.Login(userLoginDto);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }
    }
}
