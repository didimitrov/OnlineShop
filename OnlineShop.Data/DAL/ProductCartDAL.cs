using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Data.DAL
{
    public static class ProductCartDAL
    {
        public static List<UsersCard> GetAllProductsForUser(string username)
        {
            var db = new OnlineShopDbContext();
            var user = db.AspNetUsers.FirstOrDefault(u => u.UserName == username);
            return db.UsersCards.Where(x => x.UserId == user.Id).ToList();
        }

        public static void AddToCart(string username, int productId,int count)
        {
            var db = new OnlineShopDbContext();
            var user = db.AspNetUsers.FirstOrDefault(u => u.UserName == username);
            var product = db.Products.FirstOrDefault(p => p.Id == productId);

          var userCountCard = db.UsersCards.Count(u => u.AspNetUser.UserName == username && u.ProductId == productId);
            if (userCountCard==0)
            {
                db.UsersCards.Add(new UsersCard
                {
                    Product = product,
                    AspNetUser = user,
                    Count = count
                });
            }
            else
            {
                var userCountCart = db.UsersCards.FirstOrDefault(u => u.AspNetUser.UserName == username && u.ProductId == productId);
                if (userCountCart != null) userCountCart.Count+=count;
            }
            db.SaveChanges();  

        }
    }
}
