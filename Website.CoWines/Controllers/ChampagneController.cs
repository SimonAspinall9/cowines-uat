namespace Website.CoWines.Controllers
{
    using Enums;
    using Repositories;
    using System.Web.Mvc;

    public class ChampagneController : BaseProductController
    {
        IProductRepository _champagneRepository = new ProductRepository();

        public override ActionResult Index()
        {
            var products = _champagneRepository.GetByProductType(ProductTypes.Champagne);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult Rose()
        {
            var products = _champagneRepository.GetByProductType(ProductTypes.RoseChampagne);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult Sparkling()
        {
            var products = _champagneRepository.GetByProductType(ProductTypes.SparklingWine);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }
    }
}
