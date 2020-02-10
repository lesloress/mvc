using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class CommentController : Controller
    {
        IRepository<Comment> db;


        /*private List<string[]> comments = new List<string[]>()
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
        };*/
        private const int size = 6;

        public CommentController()
        {
            db = new Repository<Comment>();
        }

        [HttpGet]
        public ActionResult GuestRoom(int page = 0)
        {
            IEnumerable<Comment> comments = db.GetAll();

            int count = (comments as List<Comment>).Count;

            GetPages(ref comments, page);

            ViewBag.MaxPage = Max(size, count);
            ViewBag.Page = page;

            return View(comments);
        }

        [HttpPost]
        public ActionResult GuestRoom(FormCollection formCollection)
        {
            int page = 0;

            db.Add(new Comment
            {
                Name = formCollection["Name"],
                Text = formCollection["Comment"],
                Date = DateTime.Now.Date
            });

            db.Save();

            IEnumerable<Comment> comments = db.GetAll();

            int count = (comments as List<Comment>).Count;

            GetPages(ref comments, page);

            ViewBag.MaxPage = Max(size, count);
            ViewBag.Page = page;

            return View(comments);
        }

        private IEnumerable<Comment> GetPages(ref IEnumerable<Comment> comments, int page = 0)
        {
            comments = comments
                .OrderByDescending(c => c.Date)
                .Skip(page * size)
                .Take(size)
                .ToList();
            return comments;
        }

        private int Max(int size, int count) => (count / size) - (count % size == 0 ? 1 : 0);
    }
}