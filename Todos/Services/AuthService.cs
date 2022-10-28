using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Todos.Interfaces;
using Todos.Model;
using Todos.Model.Auth;

namespace Todos.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Auth>> GetAsync() =>
            await _repository.GetAsync();

        public async Task<Auth?> GetAsync(string id) =>
            await _repository.GetAsync(id);

        public async Task CreateAsync(Auth newUser) =>
            await _repository.CreateAsync(newUser);

        public async Task UpdateAsync(string id, Auth updatedUser) =>
            await _repository.UpdateAsync(id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await _repository.DeleteAsync(id);
    }
}

/*
 public User Register(UserDto request)
        {
            CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);

            // TODO: Validate no duplicate usernames in db. (encrypt in mongoose?)
            // Throw exception if duplicate.

            return new User();
        }

        public async Task<ActionResult<User>> Login(UserDto request)
        {
            // NOTE: Fix this to communicate with DB.
            // if (user.Username != request.username)
            // {
            //    throw new BadHttpRequestException("No user found");
            // }

            // NOTE: Fix this to commuinicate with DB.(verify in mongoose?)
            // if (!VerifyPasswordHash(request.password, user.PasswordHash, user.PasswordSalt))
            // {
            //    throw new BadHttpRequestException("Wrong password");
            //}

            return new User();

        }

        // NOTE: Move to mongoose?
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new();

            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new(passwordSalt);
            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
 */
