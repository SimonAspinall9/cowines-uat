using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website.CoWines.Repositories;
using Website.CoWines.ViewModel;

namespace Website.CoWines.Controllers
{
    public class AdminController : BaseAdminController
    {
        IProductRepository _productRepository = new ProductRepository();

        public ActionResult Index()
        {
            return RedirectToAction("Products");
        }

        public ActionResult Products()
        {
            var productViewModels = MapToProductViewModels(_productRepository.Get()).ToList();

            return View(productViewModels);
        }

        public ActionResult ProductDetails(int id)
        {
            var product = _productRepository.GetById(id);
            var productViewModel = MapToProductViewModel(product);

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Products(List<ProductViewModel> products)
        {
            return RedirectToAction("Products");
        }
    }
}