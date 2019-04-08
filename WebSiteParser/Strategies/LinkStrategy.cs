namespace WebSiteParser.Strategies
{
    using HtmlAgilityPack;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Get all links from the URL
    /// </summary>
    public class LinkStrategy : IStrategy
    {
        public List<string> Parse(HtmlDocument doc)
        {
            var links = doc.DocumentNode.SelectNodes("//a[@href]")
                .Select(a => a.Attributes["href"].Value)
                .Where(x => x.StartsWith("http"))
                .Distinct()
                .ToList();

            return links;
        }
    }
}