namespace Website.CoWines.Repositories
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string NullSafeName()
        {
            if (this == null)
            {
                return string.Empty;
            }

            return Name;
        }
    }
}
