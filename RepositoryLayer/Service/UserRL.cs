using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using ModelLayer.DTO;
using System.Linq;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly AddressContext _context;

        public UserRL(AddressContext context)
        {
            _context = context;
        }

        public User LoginUser(LoginDTO loginDTO)
        {
            return _context.Users.FirstOrDefault(u => u.Email == loginDTO.Email);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
