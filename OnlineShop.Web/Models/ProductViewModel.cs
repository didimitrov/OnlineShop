using OnlineShop.Data.DAL;

namespace OnlineShop.Web.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(string name, decimal price, int id, string image,byte rating)
        {
            Id=id;
            Name = name;
            Price = price;
            Image = image;
            Rating = rating;
            //Quanty = quanty;
        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price= product.Price;
            Image = product.Image;
            Rating = product.Rating;
            //Quanty = product.Quanty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public byte Rating { get; set; }
        //public int Quanty { get; set; }
    }
}