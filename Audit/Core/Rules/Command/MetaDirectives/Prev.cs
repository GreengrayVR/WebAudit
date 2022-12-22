using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class Prev : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            //var links = document.DocumentNode.SelectNodes("//link[@rel]");
            //if (links == null) return;
            //foreach (HtmlNode link in links)
            //{
            //    if (link.Attributes["rel"]?.Value == "prev")
            //    {
            //        // statistic.MetaDirectives.Prev = new Rule<bool, ErrorType.Warning>(true);
            //        statistic.Rules.Add(new Rule()
            //        {
            //            Name = "Prev",
            //            Description = "??",
            //            ErrorLevel = Error.Warning,
            //        });
            //        return;
            //    }
            //}
        }
    }
}
