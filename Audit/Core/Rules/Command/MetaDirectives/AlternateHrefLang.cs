using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class AlternateHrefLang : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
           //var links = document.DocumentNode.SelectNodes("//link[@rel]");
           //if (links == null) return;
           //foreach (HtmlNode link in links)
           //{
           //    if (link.Attributes["rel"]?.Value == "alternate")
           //    {
           //        //statistic.MetaDirectives.AlternateHrefLang = new Rule<bool, ErrorType.Warning>(true);
           //        statistic.Rules.Add(new Rule()
           //        {
           //            Name = "AlternateHrefLang",
           //            Description = "??",
           //            ErrorLevel = Error.Warning,
           //        });
           //        return;
           //    }
           //}
            // Add else here
        }
    }
}
