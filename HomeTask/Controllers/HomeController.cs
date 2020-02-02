using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class HomeController : Controller
    {
        private List<string[]> articles = new List<string[]>()
        {
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            },
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            },
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            },
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            },
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            },
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            },
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            },
            new string[]
            {
                "Статья",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                "01.02.2020"
            }
        };
        private string[] resources = {
            "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#, Джеффри Рихтер.",
            "C# 7.0 in a Nutshell: The Definitive Reference, Joseph Albahari, Ben Albahari",
            "Effective C# и More Effective C#, Bill Wagner"
        };
        private const int size = 3;

        public ActionResult Index(int page = 0)
        {
            List<string[]> data = articles.Skip(page * size).Take(size).ToList();

            int count = articles.Count;
            this.ViewBag.MaxPage = (count / size) - (count % size == 0 ? 1 : 0);

            this.ViewBag.Page = page;

            ViewBag.Articles = data;

            return View();
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

            ViewBag.Result = $"{sum*100/5} %";
            ViewBag.Resources = resources;

            return View("QuestionaryResult");
        }
    }
}