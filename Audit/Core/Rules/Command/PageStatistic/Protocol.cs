using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.PageStatistic
{
    public class Protocol : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            statistic.PageStatistic.Protocol = httpResponseMessage.RequestMessage.RequestUri.GetLeftPart(UriPartial.Scheme);
        }
    }
}
