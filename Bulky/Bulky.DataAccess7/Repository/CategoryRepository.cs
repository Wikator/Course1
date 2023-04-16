using BulkyBook.DataAccess7.Data;
using BulkyBook.DataAccess7.Repository.IRepository;
using BulkyBook.Models7;

namespace BulkyBook.DataAccess7.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
		}

		public void Update(Category category)
		{
			_db.Categories.Update(category);
		}
	}
}
