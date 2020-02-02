using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class CommentController : Controller
    {
        private List<string[]> comments = new List<string[]>()
        {
            new string[] {"Ivan Ivanov", 
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"},
            new string[] {"Ivan Ivanov",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "01.02.2020"}
        };
        private const int size = 6;

        [HttpGet]
        public ActionResult GuestRoom(int page = 0)
        {
            List<string[]> data = comments.Skip(page * size).Take(size).ToList();

            int count = comments.Count;
            ViewBag.MaxPage = (count / size) - (count % size == 0 ? 1 : 0);

            ViewBag.Page = page;

            ViewBag.Comments = data;

            return View();
        }

        [HttpPost]
        public ActionResult GuestRoom(FormCollection formCollection)
        {
            int page;

            if (string.IsNullOrWhiteSpace(formCollection["Name"]) 
                || string.IsNullOrWhiteSpace(formCollection["Comment"]))
            {
                page = Convert.ToInt32(formCollection["Page"]);
                Response.Write("<script>alert('Заполните все поля!')</script>");
            }

            else
            {
                page = 0;
                string[] comment = { formCollection["Name"], formCollection["Comment"],
                DateTime.Now.ToShortDateString()};
                comments.Insert(0, comment);
            }

            List<string[]> data = comments.Skip(page * size).Take(size).ToList();

            int count = comments.Count;
            ViewBag.MaxPage = (count / size) - (count % size == 0 ? 1 : 0);

            ViewBag.Page = page;

            ViewBag.Comments = data;

            return View();

        }
    }
}