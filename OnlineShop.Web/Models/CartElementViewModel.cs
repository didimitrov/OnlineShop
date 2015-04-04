using System.Collections;
using OnlineShop.Data.DAL;

namespace OnlineShop.Web.Models
{
    public class CartElementViewModel
    {

        public CartElementViewModel(string productName, decimal unitPrice, int count,int id)
        {
            Id = id;
            Count = count;
            ProductName = productName;
            Price = count*unitPrice;
        }

        public int Id { get; set; }       
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        
    }
}