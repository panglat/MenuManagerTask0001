using BL.Abstract;
using BL.DTO;
using BL.Helper;
using Domain.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BL.Concrete
{
    public class LanguageManager: ILanguageManager
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly ITermLanguageRepository _termLanguageRepository;

        public LanguageManager(ILanguageRepository languageRepository, ITermLanguageRepository termLanguageRepository)
        {
            _languageRepository = languageRepository;
            _termLanguageRepository = termLanguageRepository;
        }
        
        public IEnumerable<LanguageDto> GetAllLanguages()
        {
            return _languageRepository.FindAll()
                .OrderBy(language => language.Name)
                .Select(language => ConverterObjectHelper.LanguageToLanguageDto(language));
        }

        public LanguageDto GetLanguage(String languageCode)
        {
            return _languageRepository.FindByCondition(language => languageCode.Equals(language.LanguageCode))
                .Select(language => ConverterObjectHelper.LanguageToLanguageDto(language))
                .FirstOrDefault();
        }

        public TermsDto GetTerms(String languageCode)
        {
            var termLanguages = _termLanguageRepository.FindByCondition(termLanguage => languageCode.Equals(termLanguage.Language.LanguageCode))
                .AsQueryable().Include(tl => tl.Language).Include(tl => tl.Term);
            var termsDto = ConverterObjectHelper.TermLanguagesToTermsDto(termLanguages);
            return termsDto;
        }
    }
}
