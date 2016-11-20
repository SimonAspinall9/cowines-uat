using System.Collections.Generic;
using System.Web.Mvc;
using Website.CoWines.Models;
using Website.CoWines.Repositories;
using Website.CoWines.ViewModel;

namespace Website.CoWines.Controllers
{
    public class ProductController : BaseProductController
    {
        IProductRepository _productRepository = new ProductRepository();
        EditProductsRepository _editRepository = new EditProductsRepository();

        public ActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product);

            return RedirectToAction("Products", "Admin");
        }

        public ActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);
            //var productViewModel = MapToProductViewModel(product);
            var editViewModel = MapToEditViewModel(product);

            return View(editViewModel);
        }

        public ActionResult Copy(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Add(product);

            return RedirectToAction("Products", "Admin");
        }

        EditProductViewModel MapToEditViewModel(Product product)
        {
            return new EditProductViewModel
            {
                Product = MapToProductViewModel(product),
                BottleSizes = _editRepository.GetBottleSizes(),
                GrapeTypes = _editRepository.GetGrapeTypes(),
                Origins = _editRepository.GetOrigins(),
                Producers = _editRepository.GetProducers(),
                Sweetnesses = _editRepository.GetSweetnesses(),
                Years = _editRepository.GetYears()
            };
        }
    }
}