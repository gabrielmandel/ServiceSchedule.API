using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceSchedule.Application.Models.UserModels.Requests;
using ServiceSchedule.Application.Models.UserModels.Responses;
using ServiceSchedule.Application.Services.Interfaces;
using ServiceSchedule.Domain.User;
using ServiceSchedule.Infra.Data.Repositories;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ServiceSchedule.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteAsync(object id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task DeleteAsync(User entity)
        {
            await _userRepository.DeleteAsync(entity);
        }

        public async Task<GetUserListResponse> Get(GetUserListRequest request)
        {
            var userList = await _userRepository.Get(user => user.FirstName == request.FirstName).ToListAsync();

            var response = userList.Select(o => new GetUserResponse
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                Email = o.Email,
                ProfileImageUrl = o.ProfileImageUrl,
                IsActive = o.IsActive,
                DateOfBirth = o.DateOfBirth,
            }).ToList();

            return new GetUserListResponse
            {
                UserList = response
            };
        }

        public GetUserListResponse GetAll()
        {
            var userList = _userRepository.GetAll().ToList();

            var response = userList.Select(o => new GetUserResponse
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                Email = o.Email,
                ProfileImageUrl = o.ProfileImageUrl,
                IsActive = o.IsActive,
                DateOfBirth = o.DateOfBirth,
            });

            return new GetUserListResponse
            {
                UserList = response.ToList()
            };
        }

        public async Task<GetUserResponse> GetByIDAsync(object id)
        {
            var user = await _userRepository.GetByIDAsync(id);

            return new GetUserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                IsActive = user.IsActive,
                DateOfBirth = user.DateOfBirth,
            };
        }

        public Task InsertAsync(PostUserRequest entity)
        {
            CreatePasswordHash(entity.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Username = entity.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                ProfileImageUrl = entity.ProfileImageUrl,
                DateOfBirth = entity.DateOfBirth,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return _userRepository.InsertAsync(user);
        }

        public Task UpdateAsync(User entity)
        {
            return _userRepository.UpdateAsync(entity);
        }
        
        public User? Login(PostUserLoginRequest request)
        {
            var user = _userRepository.Get(user => user.Username == request.Username).FirstOrDefault();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
