using System.Collections.Generic;
using System.Linq;
using Website.CoWines.DAL;
using Website.CoWines.Models;

namespace Website.CoWines.Repositories
{
    public class EditProductsRepository
    {
        public ICollection<BottleSize> GetBottleSizes()
        {
            ICollection<BottleSize> bottleSizes;

            using (var dbContext = new ApplicationDbContext())
            {
                bottleSizes = (from b in dbContext.BottleSizes
                               select b).ToList();
            }

            return bottleSizes;
        }

        public ICollection<GrapeType> GetGrapeTypes()
        {
            ICollection<GrapeType> grapeTypes;

            using (var dbContext = new ApplicationDbContext())
            {
                grapeTypes = (from g in dbContext.GrapeTypes
                              select g).ToList();
            }

            return grapeTypes;
        }

        public ICollection<Origin> GetOrigins()
        {
            ICollection<Origin> origins;

            using (var dbContext = new ApplicationDbContext())
            {
                origins = (from o in dbContext.Origins
                           select o).ToList();
            }

            return origins;
        }

        public ICollection<Producer> GetProducers()
        {
            ICollection<Producer> producers;

            using (var dbContext = new ApplicationDbContext())
            {
                producers = (from p in dbContext.Producers
                             select p).ToList();
            }

            return producers;
        }

        public ICollection<Sweetness> GetSweetnesses()
        {
            ICollection<Sweetness> sweetnesses;

            using (var dbContext = new ApplicationDbContext())
            {
                sweetnesses = (from s in dbContext.Sweetnesses
                               select s).ToList();
            }

            return sweetnesses;
        }

        public ICollection<Year> GetYears()
        {
            ICollection<Year> years;

            using (var dbContext = new ApplicationDbContext())
            {
                years = (from y in dbContext.Years
                         select y).ToList();
            }

            return years;
        }
    }