using Contracts.Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
