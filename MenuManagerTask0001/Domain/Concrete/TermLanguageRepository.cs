using Domain.Abstract;
using Domain.Context;
using Domain.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Concrete
{
    public class TermLanguageRepository : RepositoryBase<TermLanguage>, ITermLanguageRepository
    {
        public TermLanguageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }

}
