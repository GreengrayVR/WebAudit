using Audit.Core.Statistics;
using HtmlAgilityPack;

namespace Audit.Core.Rules.Command.PageContent
{
    public class Images : IParseRule
    {
        public void Parse(Statistic statistic, HttpResponseMessage httpResponseMessage, HtmlDocument document)
        {
            var imgs = document.DocumentNode.SelectNodes("//img");
            if (imgs == null) return;

            bool result = false;
            foreach (var img in imgs)
            {
                if(img.Attributes["alt"] == null)
                    result = true;
            }
            //statistic.PageContent.ImageNoAlt = new Rule<bool, ErrorType.Good>(result);
            if(result) statistic.Rules.Add(new Rule() { Name = "Зображення з відсутнім або пустим атрибутом alt", Description = "Атрибут alt використовується пошуковими системами для ранжування зображень в пошуку, він допомагає визначити, що зображено на картинці. Таким чином зображення без атрибута alt не можуть нормально ранжуватися. Також атрибут alt впливає на ранжування самої html сторінки, на якій знаходиться зображення.", ErrorLevel = Error.Warning });
        }
    }
}
