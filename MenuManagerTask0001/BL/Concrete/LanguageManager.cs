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
        
        private readonly ILanguageRepository languageRepository;

        public LanguageManager(ILanguageRepository _languageRepository)
        {
            languageRepository = _languageRepository;
        }
        
        public IEnumerable<Language> GetAllLanguages()
        {
            return languageRepository.FindAll()
                .OrderBy(language => language.Name);
        }
    }
}
