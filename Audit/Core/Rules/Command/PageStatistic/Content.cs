using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.PageStatistic
{
    public class Content : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            statistic.PageStatistic.Content = httpResponseMessage.Content.ReadAsStringAsync().Result;


        }
    }
}
