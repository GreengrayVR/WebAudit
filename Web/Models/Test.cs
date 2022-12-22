using Audit.Core.Pages;

namespace Web.Models
{
    public class Test
    {
        public List<string>? URLS { get; set; }

        public Dictionary<string, IEnumerable<Page>>? pages { get; set; }
    }
}
