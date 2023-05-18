using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult CommentListForBlog(int id) 
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult AddCommentForBlog() 
        { 
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddCommentForBlog(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = 2;
            cm.AddComment(p);
            return PartialView();
        }
    }
}
