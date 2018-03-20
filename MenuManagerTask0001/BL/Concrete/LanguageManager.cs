using BL.Abstract;
using Domain.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        public IEnumerable<Language> GetAllLanguages()
        {
            return _languageRepository.FindAll()
                .OrderBy(language => language.Name);
        }

        public Language GetLanguage(String languageCode)
        {
            return _languageRepository.FindByCondition(language => languageCode.Equals(language.LanguageCode)).FirstOrDefault();
        }

        public IEnumerable<TermLanguage> GetTerms(String languageCode)
        {
            return _termLanguageRepository.FindByCondition(termLanguage => languageCode.Equals(termLanguage.Language.LanguageCode));
        }
    }
}
