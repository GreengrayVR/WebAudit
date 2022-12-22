using Audit.Core.Rules;
using Audit.Core.Rules.ErrorType;

namespace Audit.Core.Statistics
{
    public class PageStatistic
    {
        public long PageSize { get; set; }
        public IEnumerable<string> Links { get; set; } = new List<string>();
        public long LoadingPageTime { get; set; }
        public string Content { get; set; } = string.Empty;
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public string Protocol { get; set; } = string.Empty;
    }
}
