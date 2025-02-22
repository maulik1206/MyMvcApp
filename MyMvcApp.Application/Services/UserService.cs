using AutoMapper;
using MyMvcApp.Application.DTOs;
using MyMvcApp.Application.Interfaces;
using MyMvcApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcApp.Application.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _unitOfWork.Users.GetAllUsersAsync());
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _unitOfWork.Users.GetUserByIdAsync(id));
        }

        public async Task CreateUserAsync(UserDTO user)
        {
            var userExist = await _unitOfWork.Users.GetUserByEmail(user.Email);
            if (userExist == null)
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
                await _unitOfWork.Users.AddUserAsync(_mapper.Map<User>(user));
            } 
            else
            {
                throw new Exception("User already exist.");
            }
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            await _unitOfWork.Users.UpdateUserAsync(_mapper.Map<User>(user));
        }

        public async Task DeleteUserAsync(int id) => await _unitOfWork.Users.DeleteUserAsync(id);

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(email);
            if (user == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}
