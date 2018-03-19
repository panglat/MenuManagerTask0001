using Domain.Abstract;
using Domain.Context;
using Domain.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Concrete
{
    public class TermRepository : RepositoryBase<Term>, ITermRepository
    {
        public TermRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
