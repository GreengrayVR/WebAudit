using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.PageStatistic
{
    public class StatusCode : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage response, HtmlDocument document)
        {
            statistic.PageStatistic.StatusCode = response.StatusCode;
        }
    }
}
