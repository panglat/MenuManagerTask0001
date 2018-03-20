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
                return StatusCode(500, "Internal server error");
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
                return Ok(new List<Language>());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
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
                return Ok(new List<Term>());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /*
        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage([FromRoute] int id, [FromBody] Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != language.LanguageId)
            {
                return BadRequest();
            }

            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Languages
        [HttpPost]
        public async Task<IActionResult> PostLanguage([FromBody] Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Language.Add(language);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguage", new { id = language.LanguageId }, language);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var language = await _context.Language.SingleOrDefaultAsync(m => m.LanguageId == id);
            if (language == null)
            {
                return NotFound();
            }

            _context.Language.Remove(language);
            await _context.SaveChangesAsync();

            return Ok(language);
        }

        private bool LanguageExists(int id)
        {
            return _context.Language.Any(e => e.LanguageId == id);
        }*/
    }
}