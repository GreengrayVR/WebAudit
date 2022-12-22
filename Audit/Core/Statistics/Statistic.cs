using Audit.Core.Rules;

namespace Audit.Core.Statistics
{
    public class Statistic
    {
        public List<Rule> Rules { get; set; } = new List<Rule>();
        public PageStatistic PageStatistic { get; set; } = new PageStatistic();
        // public PageContent PageContent { get; set; } = new PageContent();
        // public MetaDirectives MetaDirectives { get; set; } = new MetaDirectives();
    }
}
