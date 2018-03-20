using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BL.DTO
{
    public class TermsDto
    {
        public LanguageDto Language;
        public dynamic Terms = new ExpandoObject();
    }
}
