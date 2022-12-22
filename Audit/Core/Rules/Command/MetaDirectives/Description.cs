using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class Description : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            var metas = document.DocumentNode.SelectNodes("//meta[@name]");
            if (metas == null) return;

            int descriptionCount = 0;
            foreach (HtmlNode meta in metas)
            {
                if (meta.Attributes["name"]?.Value == "description")
                {
                    descriptionCount++;
                    string content = meta.Attributes["content"].Value;
                    /*statistic.MetaDirectives.DescriptionNullOrEmpty = new Rule<bool, ErrorType.Critical>*/
                    if(content.Length <= 0)
                        statistic.Rules.Add(new Rule()
                        {
                            Name = "Відсутній або порожній тег <meta name=\"description\" />.",
                            Description = "Мета-тег description — це важливий елемент пошукової оптимізації, тому що його вміст часто використовується як опис результату пошуку. Якщо description сторінки відсутній, пошукові системи можуть самостійно створити її опис у пошуку, виходячи з тексту на сторінці, і він може виявитися недоречним та нецікавим для користувачів. https://developers.google.com/search/docs/appearance/snippet",
                            ErrorLevel = Error.Danger,
                        });

                    /*statistic.MetaDirectives.DescriptionGreater320Length = new Rule<bool, ErrorType.Good>*/
                    if(content.Length > 320)
                        statistic.Rules.Add(new Rule()
                        {
                            Name = "Довжина тега <meta name=\"description\" /> більше 320 символів",
                            Description = "Мета-тег description — це важливий елемент пошукової оптимізації, тому що його вміст часто використовується як опис результату пошуку. Пошукові системи не вказують мінімальну та максимальну кількість символів для опису. Але для їх ефективного використання варто орієнтуватися на максимальну довжину, яка відображається у пошуковій видачі. https://developers.google.com/search/docs/appearance/snippet",
                            ErrorLevel = Error.Information,
                        });

                    /*statistic.MetaDirectives.DescriptionLess50Length = new Rule<bool, ErrorType.Good>*/
                    if(content.Length < 50)
                        statistic.Rules.Add(new Rule()
                        {
                            Name = "Довжина тега <meta name=\"description\" /> менше 50 символів.",
                            Description = "Мета-тег description - це важливий елемент пошукової оптимізації, так як його вміст часто використовується як опис результату пошуку. Якщо description сторінки короткий, пошукові системи можуть самостійно змінити її опис у пошуку, виходячи з тексту на сторінці, і він може виявитися недоречним та нецікавим для користувачів. https://developers.google.com/search/docs/appearance/snippet",
                            ErrorLevel = Error.Information,
                        });
                    return;
                }
            }
            /*statistic.MetaDirectives.DescriptionMoreThenOne = new Rule<bool, ErrorType.Warning>*/
            if(descriptionCount > 1)
                statistic.Rules.Add(new Rule()
                {
                    Name = "Дублікт тега <meta name=\"description\" />.",
                    Description = "Мета-тег description - це важливий елемент пошукової оптимізації, так як його вміст часто використовується як опис результату пошуку. Якщо description дублюється, пошукові системи можуть самостійно змінити опис сторінки у пошуку, виходячи з тексту на сторінці, і він може виявитися недоречним та нецікавим для користувачів. https://developers.google.com/search/docs/appearance/snippet",
                    ErrorLevel = Error.Warning,
                });
        }
    }
}
