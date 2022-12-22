using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.PageContent
{
    public class Heading : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {

            string? h1 = document.DocumentNode.SelectSingleNode("//h1")?.InnerText;

            if (h1 == null)
                statistic.Rules.Add(new Rule()
                {
                    Name = "Тег <h1> відсутній або порожній",
                    Description = "Тег title - це важливий елемент пошукової оптимізації. Він використовується для позначення найбільш важливого заголовку на сторінці і допомагає користувачам зрозуміти зміст вебсторінки. Відсутність тегу h1 може погіршити позицію сторінки в результатах пошуку.",
                    ErrorLevel = Error.Warning,
                });

            if(h1 == null) return;


            ////statistic.PageContent.H1LengthGreater65Length = new Rule<bool, ErrorType.Good>(h1.Length > 65);
            //if(h1.Length > 65)
            //    statistic.Rules.Add(new Rule()
            //    {
            //        Name = "H1LengthGreater65Length",
            //        Description = "??",
            //        ErrorLevel = Error.Information,
            //    });

            ////statistic.PageContent.H1LengthLess10Length = new Rule<bool, ErrorType.Good>(h1.Length < 10);
            //if (h1.Length < 10)
            //    statistic.Rules.Add(new Rule()
            //    {
            //        Name = "H1LengthLess10Length",
            //        Description = "??",
            //        ErrorLevel = Error.Information,
            //    });

            //var h1Nodes = document.DocumentNode.SelectNodes("//h1");
            //if (h1Nodes == null) return;
            ///*statistic.PageContent.H1MoreThenOne = new Rule<bool, ErrorType.Good>*/
            //if(h1Nodes.Count > 1)
            //    statistic.Rules.Add(new Rule() { Name = "H1MoreThenOne", Description = "??", ErrorLevel = Error.Information });
        }
    }
}
