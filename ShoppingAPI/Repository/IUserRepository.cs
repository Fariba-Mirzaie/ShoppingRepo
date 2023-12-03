using ShoppingAPI.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repository
{
    public interface IUserRepository
    {
        public User Register(User user);
        public User GetUser(User user);
    }
}
