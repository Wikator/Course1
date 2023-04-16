using BulkyBook.Models7;

namespace BulkyBook.DataAccess7.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category category);
	}
}
