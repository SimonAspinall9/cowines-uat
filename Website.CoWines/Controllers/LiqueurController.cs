namespace Website.CoWines.Controllers
{
    using Enums;
    using Repositories;
    using System.Web.Mvc;

    public class LiqueurController : BaseProductController
    {
        IProductRepository _liqueurRepository = new ProductRepository();

        public override ActionResult Index()
        {
            var products = _liqueurRepository.GetByProductType(ProductTypes.Liqueur);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult Port()
        {
            var products = _liqueurRepository.GetByProductType(ProductTypes.Port);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }
    }
}
