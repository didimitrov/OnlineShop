using OnlineShop.Data.DAL;

namespace OnlineShop.Web.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(string name, decimal price, int id)
        {
            Id=id;
            Name = name;
            Price = price;
            //Quanty = quanty;
        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price= product.Price;
            //Quanty = product.Quanty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public int Quanty { get; set; }
    }
}