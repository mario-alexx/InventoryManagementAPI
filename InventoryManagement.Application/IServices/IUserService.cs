using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IServices
{
    /// <summary>
    /// Service interface for managing users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of users.</returns>
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();

        /// <summary>
        /// Gets a user by its identifier.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The user.</returns>
        Task<UserDTO> GetUserByIdAsync(int id);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="UserDTO">The user DTO.</param>
        /// <returns>The added user.</returns>
        Task<UserDTO> AddUserAsync(UserDTO userDto);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="UserDTO">The user DTO.</param>
        /// <returns>The updated user.</returns>
        Task<UserDTO> UpdateUserAsync(UserDTO userDto);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteUserAsync(int id);
    }
}
