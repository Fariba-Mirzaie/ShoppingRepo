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

        public string Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public User Register(UserDTO userDto)
        {
            var userMapped = _mapper.Map<UserDTO, User>(userDto);
            _context.Users.Add(userMapped);
            _context.SaveChanges();

            return userMapped;
        }
    }
}
