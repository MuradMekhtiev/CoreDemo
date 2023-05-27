using BusinessLayer.Concrete;
using CoreDemo.Models;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		[Authorize]
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			Context c = new Context();
			var writerName = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterName).FirstOrDefault();
			ViewBag.v2 = writerName;
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult Test()
		{
			return View();
		}
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
		
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}
		[HttpGet]
		public IActionResult WriterEditProfile() 
		{
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerID = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = writerManager.TGetById(writerID);
			return View(writervalues);
		}
		[HttpPost]
        public IActionResult WriterEditProfile(Writer writer, AddProfileImage p)
		{
            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"];
			if (pas1 == pas2)
			{
				writer.WriterPassword = pas2;
				WriterValidator validationRules = new WriterValidator();
				ValidationResult results = validationRules.Validate(writer);
				if (results.IsValid)
				{
                    if (p.WriterImage != null)
                    {
                        var extension = Path.GetExtension(p.WriterImage.FileName);
                        var newimagename = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                        var stream = new FileStream(location, FileMode.Create);
                        p.WriterImage.CopyTo(stream);
                        writer.WriterImage = newimagename;
                    }
                    writerManager.TUpdate(writer);
                    return RedirectToAction("Index", "Dashboard");
                }
				else
				{
					foreach (var item in results.Errors)
					{
						ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					}
				}
			}
			else
			{
				ViewBag.error = "Password did not match!";
			}
			return View();

		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"];
			if (pas1 == pas2)
			{
				p.WriterPassword = pas2;
                Writer writer = new Writer();
                if (p.WriterImage != null)
                {
                    var extension = Path.GetExtension(p.WriterImage.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    p.WriterImage.CopyTo(stream);
                    writer.WriterImage = newimagename;
                }
                writer.WriterEmail = p.WriterEmail;
                writer.WriterName = p.WriterName;
                writer.WriterPassword = p.WriterPassword;
                writer.WriterStatus = true;
                writer.WriterAbout = p.WriterAbout;
                writerManager.TAdd(writer);
                return RedirectToAction("Index", "Dashboard");
            }
			else
			{
                ViewBag.error = "Password did not match!";
                return View();
            }
        }
    }
}
