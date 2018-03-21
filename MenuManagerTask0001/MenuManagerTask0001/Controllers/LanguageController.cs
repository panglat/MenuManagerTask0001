using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Context;
using Domain.Models;
using BL.Abstract;

namespace MenuManagerTask0001.Controllers
{
    [Produces("application/json")]
    [Route("api/languages")]
    public class LanguageController : Controller
    {
        private readonly ILanguageManager _languageManager;

        public LanguageController(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }
        
        // GET: api/Languages
        [HttpGet]
        public IActionResult GetLanguage()
        {
            try
            {
                var languages = _languageManager.GetAllLanguages();

                return Ok(languages);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: api/Languages/en
        [HttpGet("{codeLanguage}")]
        public IActionResult GetLanguage([FromRoute] string codeLanguage)
        {
            try
            {
                if(codeLanguage != null && codeLanguage.Length > 0) { 
                    var language = _languageManager.GetLanguage(codeLanguage);
                    if(language != null)
                    {
                        return Ok(language);
                    }
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: api/Languages/en
        [HttpGet("{codeLanguage}/terms")]
        public IActionResult GetTerms([FromRoute] string codeLanguage)
        {
            try
            {
                if (codeLanguage != null && codeLanguage.Length > 0)
                {
                    var terms = _languageManager.GetTerms(codeLanguage);
                    if (terms != null)
                    {
                        return Ok(terms);
                    }
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}