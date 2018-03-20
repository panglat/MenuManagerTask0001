using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface ILanguageManager
    {
        IEnumerable<LanguageDto> GetAllLanguages();
        LanguageDto GetLanguage(String languageCode);
        TermsDto GetTerms(String languageCode);
    }
}
