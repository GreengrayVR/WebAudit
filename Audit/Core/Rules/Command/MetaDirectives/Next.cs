using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class Next : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            //var links = document.DocumentNode.SelectNodes("//link[@rel]");
            //if (links == null) return;
            //foreach (HtmlNode link in links)
            //{
            //    if (link.Attributes["rel"]?.Value == "next")
            //    {
            //        //statistic.MetaDirectives.Next = new Rule<bool, ErrorType.Warning>(true);
            //        statistic.Rules.Add(new Rule()
            //        {
            //            Name = "Next",
            //            Description = "??",
            //            ErrorLevel = Error.Warning,
            //        });
            //        return;
            //    }
            //}
        }
    }
}
