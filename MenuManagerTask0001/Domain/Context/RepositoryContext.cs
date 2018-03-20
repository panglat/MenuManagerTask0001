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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TermLanguage>().HasKey(termLocate => new {
                termLocate.LanguageId,
                termLocate.TermId
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<TermLanguage> TermLanguage { get; set; }
    }
}
