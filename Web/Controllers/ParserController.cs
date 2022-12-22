using Audit.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class ParserController : Controller
    {
        public static Test Test = new Test() {
            URLS = new List<string> { },
            pages = new Dictionary<string, IEnumerable<Audit.Core.Pages.Page>>()
        };

        private readonly ApplicationDbContext _context;

        public ParserController(ApplicationDbContext context)
        {
            _context = context;
        }

        private List<Audit.Core.Pages.Page> Filter(Audit.Core.Rules.Error errorLevel)
        {
            var pages = new List<Audit.Core.Pages.Page>();
            foreach (var item in Test.pages[User.Identity.Name])
                if (item.Statistic.Rules.Where(r => r.ErrorLevel == errorLevel).Count() > 0)
                    pages.Add(new Audit.Core.Pages.Page(item.Url, null, null));

            foreach (var item in Test.pages[User.Identity.Name])
                item.Statistic.Rules.Where(r => r.ErrorLevel == errorLevel).ToList().ForEach(rule => pages.Find(p => p.Url == item.Url).Statistic.Rules.Add((Audit.Core.Rules.Rule)rule.Clone()));

            return pages;
        }


        public ActionResult Index(string filter, int page = 1)
        {
            var user = _context.Users.Where(u => u.Name == User.Identity.Name).Include(u => u.Sites).ThenInclude(s => s.URLS).ThenInclude(u => u.Check).FirstOrDefault();
            if (user == null) return View(null);
            if (user.Sites == null) return View(null);
            if (user.Sites.Count == 0) return View(null);
         


            var site = user.Sites.ToList()[0];
            var url = site.URLS.ToList()[page - 1];
            if(url == null) return View(null);
            var p = new Audit.Core.Pages.Page(url.URL, null, null);

            p.Statistic.Rules = new List<Audit.Core.Rules.Rule>();
            foreach (var check in url.Check)
            {
                p.Statistic.Rules.Add(new Audit.Core.Rules.Rule
                {
                    Name = check.Name,
                    Description = check.Description,
                    ErrorLevel = (Audit.Core.Rules.Error)check.CriticalLevel
                });
            }
            if (filter != "" && filter != null)
            {
                Audit.Core.Rules.Error filterError = (Audit.Core.Rules.Error)Enum.Parse(typeof(Audit.Core.Rules.Error), filter, true);
                p.Statistic.Rules = p.Statistic.Rules.Where(r => r.ErrorLevel == filterError).ToList();
            }
            ViewBag.page = page;
            ViewBag.totalPages = site.URLS.Count;
            ViewBag.filter = filter;

            int totalDanger = 0;
            int totalWarning = 0;
            int totalInformation = 0;

            foreach (Site? s in user.Sites)
            {
                foreach (var urls in s.URLS)
                {
                    foreach (var check in urls.Check)
                    {
                        /*
                            Information,
                            Warning,
                            Danger
                         */
                        if (check.CriticalLevel == 1)
                            totalDanger += 1;
                        if (check.CriticalLevel == 2)
                            totalWarning += 1;
                        if (check.CriticalLevel == 3)
                            totalInformation += 1;
                    }
                }
            }

            ViewBag.TotalDanger = totalDanger;
            ViewBag.TotalWarning = totalWarning;
            ViewBag.TotalInformation = totalInformation;
            ViewBag.TotalScanned = user.Sites.ToList()[0].URLS.Count;

            return View(p);
  //        try
  //        {
  //            Test.pages.ContainsKey(User?.Identity?.Name);
  //        }
  //        catch
  //        {
  //            return RedirectToAction("Index", "Home");
  //        }
  //
  //        if (!Test.pages.ContainsKey(User?.Identity?.Name))
  //            return View();
  //
  //
  //        if (filter == "danger")
  //        {
  //            var list = Filter(Audit.Core.Rules.Error.Danger);
  //            if (list.Count == 0)
  //                return View(null);
  //
  //            int len2 = list.Count();
  //            if (page - 1 > len2 - 1 || page - 1 < 0)
  //                return View();
  //
  //            ViewBag.page = page;
  //            ViewBag.totalPages = len2;
  //            ViewBag.filter = "danger";
  //
  //            return View(list[page - 1]);
  //        }
  //
  //        if (filter == "information")
  //        {
  //            var list = Filter(Audit.Core.Rules.Error.Information);
  //            if (list.Count == 0)
  //                return View(null);
  //
  //            int len2 = list.Count();
  //            if (page - 1 > len2 - 1 || page - 1 < 0)
  //                return View();
  //
  //            ViewBag.page = page;
  //            ViewBag.totalPages = len2;
  //            ViewBag.filter = "information";
  //
  //            return View(list[page - 1]);
  //        }
  //
  //        if (filter == "warning")
  //        {
  //            var list = Filter(Audit.Core.Rules.Error.Warning);
  //            if (list.Count == 0)
  //                return View(null);
  //
  //            int len2 = list.Count();
  //            if (page - 1 > len2 - 1 || page - 1 < 0)
  //                return View();
  //
  //            ViewBag.page = page;
  //            ViewBag.totalPages = len2;
  //            ViewBag.filter = "warning";
  //
  //            return View(list[page - 1]);
  //        }
  //
  //
  //
  //        int len = Test.pages[User.Identity.Name].Count();
  //        if (page - 1 > len - 1 || page - 1 < 0)
  //            return View();
  //
  //        ViewBag.page = page;
  //        ViewBag.totalPages = len;
  //        ViewBag.filter = "";
  //
  //        return View(Test.pages[User.Identity.Name].ToList()[page - 1]);
        }

        public ActionResult Search(string searchUrl)
        {
            var user = _context.Users.Where(u => u.Name == User.Identity.Name).Include(u => u.Sites).ThenInclude(s => s.URLS).ThenInclude(u => u.Check).FirstOrDefault();
            if (user == null) return View();
            if (user.Sites == null) return View();
            if (user.Sites.Count == 0) return View();

            //var page = Test.pages[User.Identity.Name].ToList().Where(p => p.Url.Contains(searchUrl)).FirstOrDefault();

            var url = user.Sites.ToList()[0].URLS.Where(url => url.URL.Contains(searchUrl)).FirstOrDefault();
            if (url == null) return View();
            
            var page = new Audit.Core.Pages.Page(url.URL, null, null);
            page.Statistic.Rules = new List<Audit.Core.Rules.Rule>();
            foreach(var check in url.Check)
            {
                page.Statistic.Rules.Add(new Audit.Core.Rules.Rule()
                {
                    Name = check.Name,
                    Description = check.Description,
                    ErrorLevel = (Audit.Core.Rules.Error)check.CriticalLevel
                });
            }

            return View(page);
        }

        public ActionResult Create()
        {
            var name = User.Identity?.Name;
            if (name != null)
            {
                var user = _context.Users.Where(p => p.Name == name).FirstOrDefault();

                if (user == null)
                {
                    user = new User()
                    {
                        Name = name
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    Console.WriteLine("Created a new user");
                }
            }   

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ParserOptions options)
        {
            var name = User.Identity?.Name;
            if (name == null)
                return RedirectToAction("Index");

            var user = _context.Users.Where(p => p.Name == name).Include(p => p.Sites).FirstOrDefault();
           

            if (options.URL == null)
                ModelState.AddModelError("EmptyError", "Field cannot be empty.");
            else if (!options.URL.StartsWith("http"))
                ModelState.AddModelError("HttpError", "Has to be a URL.");

            if(!ModelState.IsValid) return View(options);

            //_ = Task.Run(async () =>
            {
                var parser = new Parser(new Uri(options.URL));
                await parser.Start();
                //Test.pages[name] = parser.Pages;

                var sites = new List<Site>();
                sites.Add(new Site() { Name = parser.Pages.First().Url });
                sites[0].URLS = new List<Url>();

                foreach (var page in parser.Pages)
                {
                    sites[0].URLS.Add(new Models.Url
                    {
                        URL = page.Url,
                        Check = new List<Check>()
                    });
                    var url = sites[0].URLS.ToList().Where(url => url.URL == page.Url).First();
                    foreach (var rule in page.Statistic.Rules)
                    {
                        url.Check.Add(new Check
                        {
                            Name = rule.Name,
                            Description = rule.Description,
                            CriticalLevel = (int)rule.ErrorLevel
                        });
                    }
                }

                try
                {
                    Console.WriteLine(user.Name);
                    user.Sites = sites;
                    
                    Console.WriteLine("update");
                    _context.Update(user);
                    Console.WriteLine("save");
                    _context.SaveChanges();
                    Console.WriteLine("saved");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }


                //});
            }
            return RedirectToAction("Index");
        }
    }
}
