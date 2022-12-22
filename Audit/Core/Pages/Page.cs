using HtmlAgilityPack;
using Audit.Core.Rules;
using Audit.Core.Statistics;

namespace Audit.Core.Pages
{
    public class Page
    {
        public string Url { get; }
        public Statistic Statistic { get; }

        HttpClient _client;
        Commands _commands;
        HtmlDocument _document;
        HttpResponseMessage _httpResponseMessage;

        public Page(string url, HttpClient client, Commands commands)
        {
            Url = url;
            Statistic = new Statistic();
            _client = client;
            _commands = commands;
            _document = new HtmlDocument();
        }

        private async Task DownloadPage()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            _httpResponseMessage = await _client.GetAsync(Url);
            watch.Stop();
            Statistic.PageStatistic.LoadingPageTime = watch.ElapsedMilliseconds;
        }

        private void LoadHttpDocument()
        {
            _document.Load(_httpResponseMessage.Content.ReadAsStream());
        }

        private void Parse()
        {
            foreach (var rule in _commands.Rules)
                rule.Parse(Statistic, _httpResponseMessage, _document);
        }

        public async Task Start()
        {
            await DownloadPage();
            LoadHttpDocument();
            Parse();
        }
    }
}
