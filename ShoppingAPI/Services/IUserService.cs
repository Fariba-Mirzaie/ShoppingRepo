using ShoppingAPI.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{
    public interface IUserService
    {
        public User Register(UserDTO user);
        public User GetUser(UserDTO user);
        //public bool ValidateUser(UserDTO user);


    }
}
