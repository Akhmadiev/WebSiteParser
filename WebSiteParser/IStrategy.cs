namespace WebSiteParser
{
    using HtmlAgilityPack;
    using System.Collections.Generic;

    /// <summary>
    /// Parse web site
    /// </summary>
    public interface IStrategy
    {
        List<string> Parse(HtmlDocument doc);
    }
}
