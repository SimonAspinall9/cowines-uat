namespace Website.CoWines.Repositories
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
