using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.MetaDirectives
{
    public class Title : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            var titles = document.DocumentNode.SelectNodes("//title");
            if (titles == null) return;

            //statistic.MetaDirectives.MultipleTitles = new Rule<bool, ErrorType.Warning>(titles.Count > 1);
            if(titles.Count > 1)
                statistic.Rules.Add(new Rule() { Name = "Дублікат тегу <title>", Description = "Тег title - це важливий елемент пошукової оптимізації, так як його вміст часто використовується як назва сторінки в результатах пошуку. Якщо тег title дублюється, пошукові системи можуть самостійно змінити назву сторінки у пошуку, виходячи з тексту на сторінці, і вона може виявитися недоречною або нецікавою для користувачів. https://developers.google.com/search/docs/appearance/title-link", ErrorLevel = Error.Warning });
            if (titles.Count < 0) return;

            var titleLength = titles[0]?.InnerText.Length;

            /*statistic.MetaDirectives.TitleNullOrEmpty = new Rule<bool, ErrorType.Critical>*/
            if(titleLength <= 0) statistic.Rules.Add(new Rule() { Name = "Тег <title> відсутній або порожній", Description = "Тег title - це важливий елемент пошукової оптимізації, так як його вміст часто використовується як назва сторінки в результатах пошуку. Якщо тег title відсутній, пошукові системи можуть самостійно змінити назву сторінки у пошуку, виходячи з тексту на сторінці, і вона може виявитися недоречною або нецікавою для користувачів. https://developers.google.com/search/docs/appearance/title-link", ErrorLevel = Error.Danger });
            /*statistic.MetaDirectives.TitleGreater65Length = new Rule<bool, ErrorType.Warning>*/
            if(titleLength > 65) statistic.Rules.Add(new Rule() { Name = "Довжина тегу <title> більше 65 символів", Description = "Тег title - це важливий елемент пошукової оптимізації, так як його вміст часто використовується як назва сторінки в результатах пошуку. Пошукові системи зазвичай відображають тільки 65 перших символів з тегу title. Такий скорочений тег може виявитися нецікавим для користувачів. https://developers.google.com/search/docs/appearance/title-link", ErrorLevel = Error.Warning });
            /*statistic.MetaDirectives.TitleLess10Length = new Rule<bool, ErrorType.Warning>*/
            if(titleLength < 10) statistic.Rules.Add(new Rule() { Name = "Довжина тегу <title> менше 10 символів", Description = "Тег title - це важливий елемент пошукової оптимізації, так як його вміст часто використовується як назва сторінки в результатах пошуку. Занадто короткий title може виявитися нецікавим для користувачів. https://developers.google.com/search/docs/appearance/title-link", ErrorLevel = Error.Warning });
        }
    }
}
