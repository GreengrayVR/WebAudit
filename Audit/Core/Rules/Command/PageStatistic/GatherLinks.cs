using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.PageStatistic
{
    public class GatherLinks : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            var tag = document.DocumentNode.Descendants("a");
            statistic.PageStatistic.Links = tag.Select(a => a.GetAttributeValue("href", null))
                                             .Where(u => !string.IsNullOrEmpty(u));

            /*statistic.PageStatistic.LinkWithoutAnchor = new Rule<bool, ErrorType.Good>*/
            //if(tag.Where(a => a.InnerText == string.Empty).Count() > 0)
            //
            //    statistic.Rules.Add(new Rule() { Name = "LinkWithoutAnchor", Description = "??", ErrorLevel = Error.Information });

        }
    }
}
