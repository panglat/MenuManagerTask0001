
using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IUserManager
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto AddUser(UserDto userDto);
    }
}
