using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService: IGenericService<Blog>
	{
		List<Blog> GetLastThreeBlog();
		List<Blog> GetBlogListWithCategory();
		List<Blog> GetBlogListForWriter(int id);
	}
}
