using System;
using System.Collections.Generic;
using System.Text;

namespace IvSite.Services.HtmlSanitaizer
{
    public interface IHtmlSanitizerService
    {
        string Sanitize(string htmlContent);
    }
}
