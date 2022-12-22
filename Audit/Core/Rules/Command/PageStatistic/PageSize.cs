using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.PageStatistic
{
    public class PageSize : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage response, HtmlDocument document)
        {
            statistic.PageStatistic.PageSize = (long)response.Content.Headers.ContentLength;
            /*statistic.PageStatistic.PageSizeGreater200000Length = new Rule<bool, ErrorType.Good>*/
            if(statistic.PageStatistic.PageSize > 200000)
                statistic.Rules.Add(new Rule() { Name = "Розмір сторінки більше 200 тис. символів.", Description = "Сторінки занадто великого розміру можуть довго завантажуватися, особливо на мобільних пристроях. В результаті користувач може не дочекатися завантаження сторінки. Такі великі і повільні сторінки зазвичай займають низькі позиції в результатах пошуку.", ErrorLevel = Error.Warning });
        }
    }
}
