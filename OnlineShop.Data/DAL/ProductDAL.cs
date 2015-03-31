using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Data.DAL
{
   public static class ProductDAL
    {
      public static List<Product> GetAllProducts()
      {
          var db = new OnlineShopDbContext();
          return db.Products.ToList();
      }
    }
}
