using ShoppingSpree.Data.Models;
using ShoppingSpree.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingSpree.Data;
using System.IO;
using System.Threading.Tasks;
using ShoppingSpree.Data.ViewModels;
using ShoppingSpree.Data.ModelBuilder;
using System.Web.Mvc;

namespace ShoppingSpree.Controllers
{
    public class HomeController : Controller
    {
        ProductDbContext _db;
        ProductsModelBuilder _productsModelBuilder;

        public HomeController()
        {
            _db =new ProductDbContext();
            _productsModelBuilder = new ProductsModelBuilder(_db);
        }

        public ActionResult Index()
        {
            List<ProductViewModel> model = new List<ProductViewModel>();
            foreach (var item in _db.Products)
            {
                var imgSrc = ConvertToImgSrc(item.Image);

                model.Add(new ProductViewModel()
                {
                    productId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductColour = item.ProductColour,
                    ProductPrice = item.ProductPrice,
                    ConvertedImgSrc = imgSrc
                });
            }
            return View(model);
        }

        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productsModelBuilder.addAsync(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = _productsModelBuilder.GetById(id);
            var imgSrc = ConvertToImgSrc(item.Image);

            var model = new ProductViewModel()
            {
                productId = item.ProductId,
                ProductName = item.ProductName,
                ProductColour = item.ProductColour,
                ProductPrice = item.ProductPrice,
                ConvertedImgSrc = imgSrc
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        private string ConvertToImgSrc(byte[] img)
        {
            var base64 = Convert.ToBase64String(img);
            return string.Format("data:image/gif;base64,{0}", base64);
        }
    }
}