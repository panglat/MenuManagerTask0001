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

            if(context.Language.Any())
            {
                return; // DB has been seeded
            }

            var languages = new Language[]
            {
                new Language{ Name="English", LanguageCode="en", NativeLanguage="English" },
                new Language{ Name="Portuguese", LanguageCode="pt", NativeLanguage="Português" },
            };

            foreach(Language language in languages)
            {
                context.Language.Add(language);
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

            var termLanguages = new TermLanguage[]
            {
                new TermLanguage{ Language = languages[0], Term = terms[0], Value = "welcome" },
                new TermLanguage{ Language = languages[0], Term = terms[1], Value = "name" },
                new TermLanguage{ Language = languages[0], Term = terms[2], Value = "surname" },
                new TermLanguage{ Language = languages[1], Term = terms[0], Value = "bem vinda" },
                new TermLanguage{ Language = languages[1], Term = terms[1], Value = "nome" },
                new TermLanguage{ Language = languages[1], Term = terms[2], Value = "apelido" },
            };

            foreach (TermLanguage termLanguage in termLanguages)
            {
                context.TermLanguage.Add(termLanguage);
            }
            context.SaveChanges();
        }
    }
}
