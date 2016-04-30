namespace Website.CoWines.Repositories
{
    using DAL;
    using System.Data.Entity;
    public class BaseRepository
    {
        private ApplicationDbContext _dbContext;

        protected ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected void ChangeEntityState(IEntity entity, EntityState entityState)
        {
            DbContext.Entry(entity).State = entityState;
            DbContext.SaveChanges();
        }
    }
}
