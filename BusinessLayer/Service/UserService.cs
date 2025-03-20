using BusinessLayer.Interface;
using ModelLayer.DTO;
using RepositoryLayer.Entity;
using RepositoryLayer.Helper;
using RepositoryLayer.Interface;
using System;

namespace BusinessLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRL _userRL;
        private readonly JwtService _jwtService;

        public UserService(IUserRL userRL, JwtService jwtService)
        {
            _userRL = userRL;
            _jwtService = jwtService;
        }

        public string LoginUser(LoginDTO loginDTO)
        {
            var user = _userRL.LoginUser(loginDTO);

            if (user == null)
            {
                Console.WriteLine(" Invalid credentials: User not found!");
                return null;
            }

            var token = _jwtService.GenerateToken(user);
            Console.WriteLine(" Token Generated: " + token);
            return token;
        }

        public User RegisterUser(User user)
        {
            return _userRL.RegisterUser(user);
        }
    }
}
