using System.Collections.Generic;
using System.ComponentModel.Design;
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

      public static Product GetProductById(int id)
      {
          var db = new OnlineShopDbContext();
          return db.Products.SingleOrDefault(x => x.Id == id);

      }

      public static void AddProduct(Product product)
      {
          var db = new OnlineShopDbContext();
          if (product == null)
          {
              throw CheckoutException.Canceled;
          }
          else
          {
              db.Products.Add(product);
              db.SaveChanges();
          }

      }
    }
}
