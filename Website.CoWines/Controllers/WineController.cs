namespace Website.CoWines.Controllers
{
    using Enums;
    using Repositories;
    using System.Web.Mvc;

    public class WineController : BaseProductController
    {
        IProductRepository _wineRepository = new ProductRepository();

        public ActionResult Red()
        {
            var products = _wineRepository.GetByProductType(ProductTypes.RedWine);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult Rose()
        {
            var products = _wineRepository.GetByProductType(ProductTypes.RoseWine);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult White()
        {
            var products = _wineRepository.GetByProductType(ProductTypes.WhiteWine);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }
    }
}
