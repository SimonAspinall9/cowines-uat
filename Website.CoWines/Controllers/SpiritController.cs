namespace Website.CoWines.Controllers
{
    using Enums;
    using Repositories;
    using System.Web.Mvc;

    public class SpiritController : BaseProductController
    {
        IProductRepository _spiritRepository = new ProductRepository();

        public override ActionResult Index()
        {
            var products = _spiritRepository.GetByProductType(ProductTypes.Spirit);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult Armagnac()
        {
            var products = _spiritRepository.GetByProductType(ProductTypes.Armagnac);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult Cognac()
        {
            var products = _spiritRepository.GetByProductType(ProductTypes.Cognac);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }

        public ActionResult EauxDeVie()
        {
            var products = _spiritRepository.GetByProductType(ProductTypes.EauxDeVie);
            var productViewModels = MapToProductViewModels(products);

            return View(productViewModels);
        }
    }
}
