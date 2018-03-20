using BL.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BL.Helper
{
    public static class ConverterObjectHelper
    {
        public static LanguageDto LanguageToLanguageDto(Language language)
        {
            if (language != null)
            {
                return new LanguageDto()
                {
                    LanguageCode = language.LanguageCode,
                    Name = language.Name,
                    NativeLanguage = language.NativeLanguage
                };
            }
            else
            {
                return null;
            }
        }

        public static TermsDto TermLanguagesToTermsDto(IEnumerable<TermLanguage> termLanguages)
        {
            LanguageDto languageDto = null;
            dynamic terms = new ExpandoObject();
            if (termLanguages != null)
            {
                foreach (TermLanguage termLanguage in termLanguages)
                {
                    if (languageDto == null)
                    {
                        languageDto = LanguageToLanguageDto(termLanguage.Language);
                    }
                    ExpandoHelper.AddProperty(terms, termLanguage.Term.Value, termLanguage.Value);
                }
                if (languageDto != null)
                {
                    return new TermsDto()
                    {
                        Language = languageDto,
                        Terms = terms
                    };
                }
            }
            return null;
        }

        public static User UserDtoUser(UserDto userDto)
        {
            return new User()
            {
                Email = userDto.Email,
                Password = userDto.Password
            };
        }

        public static UserDto UserToUserDto(User user)
        {
            return new UserDto()
            {
                Email = user.Email
            };
        }
    }
}
