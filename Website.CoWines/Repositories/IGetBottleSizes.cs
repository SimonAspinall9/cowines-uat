using System.Collections.Generic;
using Website.CoWines.Models;

namespace Website.CoWines.Repositories
{
    public interface IGetBottleSizes
    {
        ICollection<BottleSize> GetBottleSizes();
    }
}