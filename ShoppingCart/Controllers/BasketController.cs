using ShoppingSpree.Data.Models;
using ShoppingSpree.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class BasketController : Controller
    {
        ProductDbContext _db;

        public BasketController()
        {
            _db = new ProductDbContext();
        }
       

        List<ProductsModel> Basket = new List<ProductsModel>();
        public ActionResult AddItemToBasket(int id)
        {
            var item = _db.Products.Find(id);
            var x = TempData["Basket"];

            if (TempData["Basket"] == null)
            {
                Basket.Add(item);
                TempData["Basket"] = Basket;
            }
            else
            {
                List<ProductsModel> Basket = TempData["Basket"] as List<ProductsModel>;
                Basket.Add(item);
                TempData["Basket"] = Basket;
            }

            return RedirectToAction("index","Home");

        }
    }
}