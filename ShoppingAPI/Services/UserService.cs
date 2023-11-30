using AutoMapper;
using ShoppingAPI.DTO;
using ShoppingAPI.Models;
using ShoppingAPI.Repository;

namespace ShoppingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository , IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;

        }

        public string Login(UserDTO user)
        {
            var result = "";
            var userMapped = _mapper.Map<UserDTO , User>(user);
            

            if (user.Username != userMapped.Username)
                result = "Username Wrong!";

            if (!BCrypt.Net.BCrypt.Verify(user.Password, userMapped.PasswordHash))
                result = "Password Wrong!";

            _userRepository.Login(user);


            return result;

        }

        public User Register(UserDTO user)
        {
            string passwordHash=BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            return _userRepository.Register(user);
        }
    }
}
