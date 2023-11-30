using ShoppingAPI.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{
    public interface IUserService
    {
        public User Register(UserDTO user);
        public string Login(UserDTO user);


    }
}
