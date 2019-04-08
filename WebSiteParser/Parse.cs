namespace WebSiteParser
{
    using HtmlAgilityPack;
    using System.Collections.Generic;

    /// <summary>
    /// Main class to parse
    /// </summary>
    public class Parse
    {
        private IStrategy Strategy;

        public Parse(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public List<string> Execute(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                url = "https://stackoverflow.com/";
            }

            var doc = new HtmlWeb().Load(url);

            return Strategy.Parse(doc);
        }
    }
}
