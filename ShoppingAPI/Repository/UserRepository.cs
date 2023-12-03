using AutoMapper;
using ShoppingAPI.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        public UserRepository(MyContext myContext, IMapper mapper)
        {
            _context = myContext;
            _mapper = mapper;

        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User GetUser(User user)
        {
            return _context.Users.Where(u => u.Username == user.Username && u.PasswordHash == user.PasswordHash).FirstOrDefault();
        }

        
    }
}
