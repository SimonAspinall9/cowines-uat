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

        public override ActionResult Index()
        {
            return RedirectToAction("Products");
        }

        public ActionResult Products()
        {
            return View(MapToProductViewModels(_productRepository.Get()));
        }

        public ActionResult ProductDetails(int id)
        {
            return View(MapToProductViewModel(_productRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult Products(List<ProductViewModel> products)
        {
            //todo: save the changes in the form to the database
            foreach (var product in products)
            {
                
            }

            return RedirectToAction("Products");
        }
    }
}