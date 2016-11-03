namespace Website.CoWines.Repositories
{
    using DAL;
    using System;
    using Models;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
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

        public IEnumerable<Customer> Get()
        {
            var customers = (from c in DbContext.Customers
                             select c).ToList();

            return customers;
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
