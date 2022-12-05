using clothes_backend.Entities.Cart;
using clothes_backend.Entities.Dal;
using System.ComponentModel.DataAnnotations.Schema;

namespace clothes_backend.Service
{
    public class CategoryModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public IEnumerable<ProductModel> products { get; set; }

    }
    public class ProductModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string title { get; set; }

        public double price { get; set; }

        public double rate { get; set; }

        public int count { get; set; }

        public string? image { get; set; }
        public string? category { get; set; }

        public IEnumerable<StockModel>? stocks { get; set; }

    }
    
    

    public class StockModel
    {
        public string? color { get; set; }
        public double size { get; set; }
        public double number { get; set; }
    }

    public class CartModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string product { get; set; }
        public string? color { get; set; }
        public double size { get; set; }
        public double number { get; set; }
        public Status status { get; set; }
    }
}
