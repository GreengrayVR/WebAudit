using Audit.Core.Pages;
using Audit.Core.Rules;

namespace Audit.Core
{
    public class Parser
    {
        private Uri _mainUrl;
        private HttpClient _client;
        private Commands _commands;
        private List<Page> _pages;
        public IEnumerable<Page> Pages => _pages;
        private int _count = 0;

        public Parser(Uri mainUrl)
        {
            _mainUrl = mainUrl;
            _client = new HttpClient();
            _commands = new Commands();
            _pages = new List<Page>();
        }

        public async Task Start()
        {
            await DownloadPage($"{_mainUrl.Scheme}://{_mainUrl.Host}{(_mainUrl.Port != 80 ? $":{_mainUrl.Port}" : "")}{_mainUrl.AbsolutePath}");
        }

        public async Task DownloadPage(string url)
        {
            if (_count++ >= 100) return;
            Console.WriteLine("Downloading {0}", url);
            var page = new Page(url, _client, _commands);
            _pages.Add(page);
            await page.Start();
            foreach (var link in page.Statistic.PageStatistic.Links)
            {
                if (link.StartsWith("http")) continue;
                if (_pages.Any(p => p.Url == $"{_mainUrl.Scheme}://{_mainUrl.Host}{(_mainUrl.Port != 80 ? $":{_mainUrl.Port}/" : "")}{link}")) continue;

                await DownloadPage($"{_mainUrl.Scheme}://{_mainUrl.Host}{(_mainUrl.Port != 80 ? $":{_mainUrl.Port}/" : "")}{link}");
            }
        }
    }
}
