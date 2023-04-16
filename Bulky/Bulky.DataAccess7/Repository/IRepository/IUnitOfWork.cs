namespace BulkyBook.DataAccess7.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }

		void Save();
	}
}
