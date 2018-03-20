using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
