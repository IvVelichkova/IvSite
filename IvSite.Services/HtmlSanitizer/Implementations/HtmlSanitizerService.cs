namespace IvSite.Services.HtmlSanitizer.Implementations
{
    using IvSite.Services.HtmlSanitaizer;
    using Ganss.XSS;
    using static Data.DataConstants;

    public class HtmlSanitizerService : IHtmlSanitizerService
    {
        private readonly HtmlSanitizer htmlSanitaizer;
        public HtmlSanitizerService()
        {
            this.htmlSanitaizer = new HtmlSanitizer();
            this.htmlSanitaizer.AllowedAttributes.Add(SanitizerClass);
            
        }

        public string Sanitize(string htmlContent)
        {
            return this.htmlSanitaizer.Sanitize(htmlContent);
        }
    }
}
