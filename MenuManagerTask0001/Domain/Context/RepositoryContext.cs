using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Locate> Locates { get; set; }
        public DbSet<Term> Terms { get; set; }
        //public DbSet<TermLocate> TermLocates { get; set; }
    }
}
