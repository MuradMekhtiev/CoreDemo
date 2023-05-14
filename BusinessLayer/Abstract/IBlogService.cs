using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
		void AddBlog(Blog category);
        void DeleteBlog(Blog category);
        void UpdateBlog(Blog category);
        List<Blog> GetAllBlog();
		Blog GetById(int id);
	}
}
