using System.Collections.Generic;

namespace Website.CoWines.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        T GetByName(string name);
        ICollection<T> Get();
    }
}
