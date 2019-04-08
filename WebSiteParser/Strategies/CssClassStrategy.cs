namespace WebSiteParser.Strategies
{
    using HtmlAgilityPack;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Get all css classes from the URL
    /// </summary>
    public class CssClassStrategy : IStrategy
    {
        public List<string> Parse(HtmlDocument doc)
        {
            var classes = doc.DocumentNode.SelectNodes("//div[@class]")
                .Select(a => a.Attributes["class"].Value)
                .Distinct()
                .ToList();

            return classes;
        }
    }
}