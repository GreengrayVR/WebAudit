using Audit.Core;
using Audit.Core.Rules;
using Audit.Core.Rules.ErrorType;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Audit
{
    //public class Program
    //{
    //    private static async Task Main()
    //    {
    //        var parser = new Parser(new Uri("http://localhost:5500"));
    //        await parser.Start();
    //        
    //        foreach (var page in parser.Pages)
    //        {
    //            Console.WriteLine(page.Url);
    //            Console.WriteLine(page.Statistic.PageStatistic.PageSize);
    //            Console.WriteLine(page.Statistic.PageStatistic.LoadingPageTime);
    //            Console.WriteLine(page.Statistic.PageStatistic.StatusCode);
    //
    //            foreach (var item in page.Statistic.Rules)
    //                Console.WriteLine("Rule: {0} Level: {1}", item.Name, item.ErrorLevel);
    //
    //            //foreach (string link in page.Statistic.PageStatistic.Links)
    //            //{
    //            //    Console.WriteLine(link);
    //            //}
    //        }
    //    }
    //}
}