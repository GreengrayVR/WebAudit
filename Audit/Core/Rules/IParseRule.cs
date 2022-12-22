using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules
{
    public interface IParseRule
    {
        void Parse(Statistic statistic, HttpResponseMessage response, HtmlDocument document);
    }
}
