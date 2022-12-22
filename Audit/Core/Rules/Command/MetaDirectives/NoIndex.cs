using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class NoIndex : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            foreach (HtmlNode? node in document.DocumentNode.Descendants("meta"))
            {
                if (node.Attributes.ToList().Where(a => a.Value.Contains("noindex")).Count() > 0)
                {
                    //statistic.MetaDirectives.NoIndex = new Rule<bool, ErrorType.Warning>(true);
                    statistic.Rules.Add(new Rule()
                    {
                        Name = "Індексація сторінки заборонена за допомогою директиви NoIndex в тегу <meta name=\"robots\" >.",
                        Description = "Директива NoIndex в Meta Robots дозволяє заборонити пошуковим системам індексувати дану сторінку. В результаті такі сторінки не попадають в пошуковий індекс. Цю директиву варто використовувати тільки для не важливих сторінок, наприклад, для сторінки особистого кабінету користувача. https://developers.google.com/search/docs/crawling-indexing/robots-metatag",
                        ErrorLevel = Error.Warning,
                    });
                    return;
                }
            }
        }
    }
}
