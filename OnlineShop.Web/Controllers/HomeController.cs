using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlineShop.Data.DAL;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewCart()
        {
            var usersCards = ProductCartDAL.GetAllProductsForUser(User.Identity.Name);
            var list = new Collection<CartElementViewModel>();
            foreach (var card in usersCards)
            {
                list.Add(new CartElementViewModel(card.Product.Name,card.Product.Price,card.Count,card.Product.Id));
            }
            return View(list);
        }

      //  [Authorize]
        public ActionResult AddToCart(int id,int count)
        {
           
            if (User.Identity.IsAuthenticated)
            {
                ProductCartDAL.AddToCart(User.Identity.Name, id, count);
                    return View();  
                }
            return View("Error");
            //throw new Exception("Error in AddtoCart");
        }

        public ActionResult ViewAllProducts()
        {
            var products = ProductDAL.GetAllProducts();
            var viewModel = products.Select(p => new ProductViewModel(p)).OrderBy(model => model.Name).ToList();
            

            return View(viewModel);
        }
    }
}