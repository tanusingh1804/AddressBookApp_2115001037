using RepositoryLayer.Entity;
using ModelLayer.DTO;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        User RegisterUser(User user);  
        User LoginUser(LoginDTO loginDTO);
        User GetUserByEmail(string email);
    }
}
