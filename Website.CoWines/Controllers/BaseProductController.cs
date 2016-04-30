namespace Website.CoWines.Controllers
{
    using Models;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModel;
    public abstract class BaseProductController : BaseController
    {
        IProductRepository _productRepository = new ProductRepository();

        public virtual ActionResult Details(int id)
        {
            var product = _productRepository.GetById(id);
            var productViewModel = MapToProductViewModel(product);

            return View(productViewModel);
        }

        protected virtual IEnumerable<ProductViewModel> MapToProductViewModels(IEnumerable<Product> products)
        {
            var productViewModels = (from p in products
                                     select new ProductViewModel
                                     {
                                         Id = p.Id,
                                         BottleSize = p.BottleSize.Name,
                                         BottlesPerCase = p.BottlesPerCase,
                                         CatalogueNumber = p.CatalogueNumber,
                                         Description = p.Description,
                                         Grape = p.GrapeType.Name,
                                         ImgUrl = p.ImgUrl ?? "~/Content/img/awaiting-image.jpg",
                                         Name = p.Name,
                                         Origin = p.Origin.Name,
                                         PriceExclVat = (p.Price * 100) / (100 + CurrentTaxYearVat.VatPercent),
                                         PriceInclVat = p.Price,
                                         Producer = p.Producer.Name,
                                         Sweetness = p.Sweetness.Name,
                                         Year = p.Year.Name
                                     });

            return productViewModels;
        }

        protected virtual ProductViewModel MapToProductViewModel(Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                BottleSize = product.BottleSize.Name,
                BottlesPerCase = product.BottlesPerCase,
                CatalogueNumber = product.CatalogueNumber,
                Description = product.Description,
                Grape = product.GrapeType.Name,
                ImgUrl = product.ImgUrl ?? "~/Content/img/awaiting-image.jpg",
                Name = product.Name,
                Origin = product.Origin.Name,
                PriceExclVat = (product.Price * 100) / (100 + CurrentTaxYearVat.VatPercent),
                PriceInclVat = product.Price,
                Producer = product.Producer.Name,
                Sweetness = product.Sweetness.Name,
                Year = product.Year.Name
            };

            return productViewModel;
        }

        protected virtual ProductViewModel GetProductById(int productId)
        {
            return MapToProductViewModel(_productRepository.GetById(productId));
        }
    }
}
