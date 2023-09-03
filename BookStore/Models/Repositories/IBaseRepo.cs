namespace BookStore.Models.Repositories
{
    public interface IBaseRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);   
    }
}
