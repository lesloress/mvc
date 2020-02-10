using Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Domain.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository() : base() { }
        public Article GetArticleWithComments(int id)
        {
            return context.Articles
                .Where(a => a.Id == id)
                .Include(a => a.Comments)
                .FirstOrDefault();
        }

        //public IList<Article> GetAnnotations(int page, int pageSize)
        //{
        //    return context.Articles
        //        .OrderByDescending(a => a.Date)
        //        .Skip(page * pageSize)
        //        .Take(pageSize)
        //        .ToList();
        //}
    }
}
