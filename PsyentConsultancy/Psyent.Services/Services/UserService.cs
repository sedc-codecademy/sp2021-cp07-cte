using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Psyent.DataAccess;
using Psyent.DataModels;
using Psyent.Models;
using Psyent.Services.CustomExceptions;
using Psyent.Services.Helpers;
using Psyent.Services.Mapper;
using Psyent.Services.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Psyent.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IOptions<AppSettings> _options;

        public UserService(IRepository<User> userRepository, IOptions<AppSettings> options) 
        {
            _userRepository = userRepository;
            _options = options;
        }

        public UserModel Authenticate(string username, string password)
        {
            if (username == string.Empty || username.Length < 8)
            {
                throw new UserException("Username cannot be ampty or below 8 characters");
            }

            if (!string.IsNullOrEmpty(password) || password.Length < 8)
            {
                throw new Exception("Password is empty or below 8 characters");
            }

            var sha256 = new SHA256CryptoServiceProvider();
            var passwordData = sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(passwordData);

            var user = _userRepository.GetAll().SingleOrDefault(x => x.Username == username && x.Password == hashedPassword);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{ user.FirstName } { user.LastName}" ),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)

            };

            return userModel;
        }


        public void Register(RegisterModel model)
        {
            if (model.Username == string.Empty || model.Username.Length < 8)
            {
                throw new UserException("Username cannot be empty or below 3 characters!");
            }

            if (!string.IsNullOrEmpty(model.Password) || model.Password.Length < 8)
            {
                throw new UserException("Password is empty or below 3 characters");
            }

            var sha256 = new SHA256CryptoServiceProvider();
            var passwordData = sha256.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(passwordData);

            var user = UserMapper.RegisterModelToUser(model);
            user.Password = hashedPassword;

            _userRepository.Add(user);
        }
    }
}
