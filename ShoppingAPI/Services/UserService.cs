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

        public User Register(UserDTO userDto)
        {
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = _mapper.Map<UserDTO, User>(userDto);

            return _userRepository.Register(user);
        }

        public User GetUser(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);

            return _userRepository.GetUser(user);



            //var user2 = new User();

            //if (ValidateUser(userDTO))
            //{
            //    user2 = _userRepository.GetUser(user);
            //    return user2;
            //}

            //else return null;

        }

        //public bool ValidateUser(UserDTO userDTO)
        //{
        //    var user = _mapper.Map<UserDTO, User>(userDTO);

        //    //if (BCrypt.Net.BCrypt.Verify(userDTO.Password, user.PasswordHash))
        //    //    return true;
        //    //else
        //    //    return false;

        //    //var ddd = BCrypt.Net.BCrypt.Verify(userDTO.Password, user.PasswordHash);

        //    //if (userDTO.Username != user.Username || !BCrypt.Net.BCrypt.Verify(userDTO.Password, user.PasswordHash))
        //    //    return false;
        //    //else
        //    //    return true;
        //}
    }
}
