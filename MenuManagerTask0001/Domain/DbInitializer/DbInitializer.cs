using Domain.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.DbInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(RepositoryContext context)
        {
            context.Database.EnsureCreated();

            if(context.Locates.Any())
            {
                return; // DB has been seeded
            }

            var locates = new Locate[]
            {
                new Locate{ Name="English", LanguageCode="en", NativeLanguage="English" },
                new Locate{ Name="Portuguese", LanguageCode="pt", NativeLanguage="Português" },
            };

            foreach(Locate locate in locates)
            {
                context.Locates.Add(locate);
            }

            context.SaveChanges();

            var terms = new Term[]
            {
                new Term{ Value="welcome" },
                new Term{ Value="name" },
                new Term{ Value="surname" },
            };

            foreach (Term term in terms)
            {
                context.Terms.Add(term);
            }

            context.SaveChanges();
        }
    }
}
