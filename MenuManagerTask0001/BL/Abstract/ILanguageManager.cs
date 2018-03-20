using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface ILanguageManager
    {
        IEnumerable<Language> GetAllLanguages();
    }
}
