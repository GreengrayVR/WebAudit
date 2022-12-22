using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class Canonical : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            var links = document.DocumentNode.SelectNodes("//link[@rel]");
            if (links == null) return;
            foreach (HtmlNode link in links)
            {
                if (link.Attributes["rel"]?.Value == "canonical")
                {
                    //statistic.MetaDirectives.Canonical = new Rule<bool, ErrorType.Warning>(true);
                    statistic.Rules.Add(new Rule()
                    {
                        Name = "Неканонічна сторінка, URL у тезі <link rel=”canonical” /> вказує на іншу сторінку.",
                        Description = "Коли сторінка доступна за кількома адресами, або ж на сайті існує кілька сторінок зі схожим контентом,пошукові системи рекомендують вказувати за допомогою тегу < linkrel =”canonical” /> яку сторінку потрібно вважати головною і показувати в пошуку.Таким чиномпошукові роботи не будуть витрачати свої ресурси на сканування повторюваних абоневажливих сторінок.https://support.google.com/webmasters/answer/139066?hl=ru",
                        ErrorLevel = Error.Warning,
                    });
                    return;
                }
            }
        }
    }
}
