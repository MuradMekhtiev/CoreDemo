using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    UserName = "Murad"
                },
                new UserComment
                {
                    ID = 2,
                    UserName = "Leyla"
                },
                new UserComment
                {
                    ID = 3,
                    UserName = "Rena"
                }
            };
            return View(commentValues);
        }
    }
}
