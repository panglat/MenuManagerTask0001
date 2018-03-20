using Domain.Abstract;
using Domain.Context;
using Domain.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Concrete
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }
    }
}
