namespace IvSite.Services.HtmlSanitizer.Implementations
{
    using System;
    using IvSite.Services.HtmlSanitaizer;
    using Ganss.XSS;
    public class HtmlSanitizerService : IHtmlSanitizerService
    {
        private readonly HtmlSanitizer htmlSanitaizer;
        public HtmlSanitizerService()
        {
            this.htmlSanitaizer = new HtmlSanitizer();
            this.htmlSanitaizer.AllowedAttributes.Add("class");
            
        }

        public string Sanitize(string htmlContent)
        {
            return this.htmlSanitaizer.Sanitize(htmlContent);
        }
    }
}
