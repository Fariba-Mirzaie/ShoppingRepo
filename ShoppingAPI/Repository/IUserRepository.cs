using ShoppingAPI.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repository
{
    public interface IUserRepository
    {
        public User Register(UserDTO user);
        public string Login(UserDTO user);
    }
}
