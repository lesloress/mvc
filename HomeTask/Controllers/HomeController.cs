using Domain.Entities;
using Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class HomeController : Controller
    {
        IArticleRepository db;

        private string[] elementaryBooks =
        {
            "Head First C#, Jennifer Greene, Andrew Stellman",
            "C# 6.0 and the .NET 4.6 Framework (7th Edition), Andrew Troelsen, Philip Japikse",
            "metanit.com"
        };
        private string[] books = 
        {
            "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#, Джеффри Рихтер.",
            "C# 7.0 in a Nutshell: The Definitive Reference, Joseph Albahari, Ben Albahari",
            "Effective C# и More Effective C#, Bill Wagner",
            "C# in Depth, Jon Skeet, Third Edition"
        };
        private const int size = 3;

        public HomeController()
        {
            db = new ArticleRepository();
        }

        public ActionResult Index(int page = 0)
        {
            IEnumerable<Article> articles = db.GetAll();

            int count = (articles as List<Article>).Count;

            articles = articles
                .OrderByDescending(a => a.Date)
                .Skip(page * size)
                .Take(size)
                .ToList();

            //Used to determine wether we need paging buttons or not
            ViewBag.MaxPage = (count / size) - (count % size == 0 ? 1 : 0);
            ViewBag.Page = page;

            return View(articles);
        }

        [HttpGet]
        public ActionResult Questionary()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Questionary(FormCollection formCollection)
        {
            int sum = 0;

            if (formCollection["First"] == "4")
                sum++;


            var s = formCollection["Second"];
            if (formCollection["Second"] == "True")
                sum++;

            if (formCollection["ThirdFirst"] != "false")
                sum++;

            if (formCollection["ThirdSecond"] != "false")
                sum++;

            if (formCollection["ThirdFirst"] != "false")
                sum++;

            int result = sum*100/5;
            ViewBag.Result = result + " %";

            if (result > 50)
                ViewBag.Resources = elementaryBooks;

            else if (result <= 50)
                ViewBag.Resources = books;


            return View("QuestionaryResult");
        }
    }
}