namespace Website.CoWines.Repositories
{
    using DAL;
    using System;
    using Models;
    using System.Data.Entity;

    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public CustomerRepository()
            : base(new ApplicationDbContext())
        {
        }

        public void Add(Customer entity)
        {
            ChangeEntityState(entity, EntityState.Added);
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            ChangeEntityState(entity, EntityState.Modified);
        }
    }
}
