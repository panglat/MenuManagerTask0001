using BL.Abstract;
using BL.DTO;
using BL.Helper;
using Domain.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _userRepository.FindAll()
                .OrderBy(user => user.Email)
                .Select(user => ConverterObjectHelper.UserToUserDto(user));
        }

        public UserDto AddUser(UserDto userDto)
        {
            // Check if the email does not exist
            User user = _userRepository.FindByCondition(u => userDto.Email.Equals(u.Email)).FirstOrDefault();
            if(user == null) { 
                user = ConverterObjectHelper.UserDtoUser(userDto);
                _userRepository.Create(user);
                _userRepository.Save();
                return ConverterObjectHelper.UserToUserDto(user);
            } else
            {
                return null;
            }
        }
    }
}
