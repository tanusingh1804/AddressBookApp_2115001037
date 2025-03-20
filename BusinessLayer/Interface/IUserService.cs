using RepositoryLayer.Entity;
using ModelLayer.DTO;

namespace BusinessLayer.Interface
{
    public interface IUserService
    {
        string LoginUser(LoginDTO loginDTO);
        User RegisterUser(User user);
    }
}
