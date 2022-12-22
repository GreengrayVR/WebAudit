using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class NoFollow : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            foreach (HtmlNode? node in document.DocumentNode.Descendants("meta"))
            {
                if (node.Attributes.ToList().Where(a => a.Value.Contains("nofollow")).Count() > 0)
                {
                    //statistic.MetaDirectives.NoFollow = new Rule<bool, ErrorType.Warning>(true);
                    statistic.Rules.Add(new Rule()
                    {
                        Name = "Заборонений перехід по посиланням за допомогою директиви NoFollow в тегу <meta name= \"robots\">",
                        Description = "Директива NoFollow в Meta Robots дозволяє заборонити пошуковим системам переходити по посиланням на сторінці. В результаті такі посилання не передають вагу сторінки іншим сторінкам. Цю директиву варто використовувати тільки для посилань на не важливі сторінки, наприклад, для посилань на сторінку кабінету користувача. https://developers.google.com/search/docs/crawling-indexing/robots-meta-tag",
                        ErrorLevel = Error.Warning,
                    });
                    return;
                }
            }
        }
    }
}
