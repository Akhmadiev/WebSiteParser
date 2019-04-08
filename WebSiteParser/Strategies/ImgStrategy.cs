namespace WebSiteParser.Strategies
{
    using HtmlAgilityPack;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Get all images from the URL
    /// </summary>
    public class ImgStrategy : IStrategy
    {
        public List<string> Parse(HtmlDocument doc)
        {
            var imagess = doc.DocumentNode.SelectNodes("//img/@src")
                .ToList();

            var images = doc.DocumentNode.SelectNodes("//img/@src")
                .Select(a => a.Attributes["src"].Value)
                .Distinct()
                .ToList();

            return images;
        }
    }
}