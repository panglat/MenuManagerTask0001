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

            var termLocates = new TermLocate[]
            {
                new TermLocate{ Locate = locates[0], Term = terms[0], Value = "welcome" },
                new TermLocate{ Locate = locates[0], Term = terms[1], Value = "name" },
                new TermLocate{ Locate = locates[0], Term = terms[2], Value = "surname" },
                new TermLocate{ Locate = locates[1], Term = terms[0], Value = "bem vinda" },
                new TermLocate{ Locate = locates[1], Term = terms[1], Value = "nome" },
                new TermLocate{ Locate = locates[1], Term = terms[2], Value = "apelido" },
            };

            foreach (TermLocate termLocate in termLocates)
            {
                context.TermLocates.Add(termLocate);
            }
            context.SaveChanges();
        }
    }
}
