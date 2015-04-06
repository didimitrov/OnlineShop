using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using OnlineShop.Data.DAL;
using OnlineShop.Web.Models;
using PagedList;

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
            if (User.Identity.IsAuthenticated)
            {
                var usersCards = ProductCartDAL.GetAllProductsForUser(User.Identity.Name);
                var list = new Collection<CartElementViewModel>();
                foreach (var card in usersCards)
                {
                    list.Add(new CartElementViewModel(card.Product.Name, card.Product.Price, card.Count, card.Product.Id));
                }
                return PartialView(list);
            }
            return PartialView("Error");

        }

        //  [Authorize]
        [HttpPost]
        public ActionResult AddToCart(int id, int count)
        {
           

            if (User.Identity.IsAuthenticated)
            {
                ProductCartDAL.AddToCart(User.Identity.Name, id, count);
                return View();
            }
            return View("Error");
            //throw new Exception("Error in AddtoCart");
        }

        public ActionResult ViewAllProducts(string currentFilter, string searchString, int? page)
        {
            //var products = ProductDAL.GetAllProducts();
            //var viewModel = products.Select(p => new ProductViewModel(p)).OrderBy(model => model.Name).ToList();
            var stories = ProductDAL.GetAllProducts();



            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var pageSize = 2;
            var pageNumber = (page ?? 1);

            if (!string.IsNullOrEmpty(searchString))
            {
                var viewModel = stories.Select(p => new ProductViewModel(p))                    
                    .Where(p => p.Name.ToLower().Contains(searchString.ToLower())).ToList();
                return View(viewModel.ToPagedList(pageNumber, pageSize));

            }
            var viewModel2 = stories.Select(p => new ProductViewModel(p)).OrderBy(model => model.Name).ToList();

            return View(viewModel2);




            //return View(viewModel);
        }
    }
}
