using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    /// <summary>
    /// Service implementation for managing users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        /// <inheritdoc />
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        /// <inheritdoc />
        public async Task<UserDTO> AddUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        /// <inheritdoc />
        public async Task<UserDTO> UpdateUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
