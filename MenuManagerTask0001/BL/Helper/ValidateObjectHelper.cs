using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Helper
{
    public static class ValidateObjectHelper
    {
        public static bool IsUserDtoValid(UserDto userDto)
        {
            return userDto != null &&
                userDto.Email != null && userDto.Email.Length > 0 && // It should be checked that is a valid email. To do in the future
                userDto.Password != null && userDto.Password.Length > 0;
        }
    }
}
