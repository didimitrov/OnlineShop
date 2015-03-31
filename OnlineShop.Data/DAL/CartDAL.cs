namespace OnlineShop.Data.DAL
{
   public static class CartDAL
    {
       public static void AddProductToCart(AspNetUser user, Product product, int count)
        {
            var db = new OnlineShopDbContext();
            db.UsersCards.Add(new UsersCard()
            {
                Product = product,
                AspNetUser = user,
                Count = count
            });
            db.SaveChanges();
        }
    }
}
