namespace SchoolERP.Persistent.IRepositories;

public interface IGenericRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> GetById(long id);
    Task<List<T>> GetByClass(string className);
    Task<List<T>> GetByName(string name);
}