using ShoppingSpree.Data;
using ShoppingSpree.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingSpree.Data.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ShoppingSpree.Controllers
{
    public class HomeController : Controller
    {
        ShoppingSpreeDbContext _db;

        public HomeController()
        {
            _db = new ShoppingSpreeDbContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            List<ProductsModel> model = new List<ProductsModel>();
            foreach (var item in _db.Products)
            {
                model.Add(item);
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
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await model.Image.InputStream.CopyToAsync(memoryStream);
                    byte[] imagebyte = memoryStream.ToArray();

                    ProductsModel newProduct = new ProductsModel()
                    {
                        ProductName = model.ProductName,
                        ProductColour = model.ProductColour,
                        ProductPrice = model.ProductPrice,
                        Image = imagebyte
                    };

                    _db.Products.Add(newProduct);
                    _db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}