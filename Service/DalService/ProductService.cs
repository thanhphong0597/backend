using clothes_backend.Entities.Dal;
using Microsoft.EntityFrameworkCore;

namespace clothes_backend.Service.DalService
{
    public interface IProduct
    {
        public Task<IEnumerable<ProductModel>> GetProductsAsync();
        public Task<ProductModel> GetProductAsync(int id);
    }

    public class ProductRepo : IProduct
    {
        private readonly Context db;

        public ProductRepo(Context db)
        {
            this.db = db;
        }

        public async Task<ProductModel> GetProductAsync(int id)
        {
            var result = await db.products!.FindAsync(id);

            var q = await (from a in db.attries
                           join s in db.stocks on a.id equals s.attriID
                           where s.productID == result.id
                           select new StockModel
                           {
                               color = a.color,
                               number = a.number,
                               size = a.size
                           }).ToListAsync();
            var data = new ProductModel
            {
                id = result.id,
                count = result.count,
                image = result.image,
                name = result.name,
                price = result.price,
                rate = result.rate,
                title = result.title,
                stocks = q
            };
            return data;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            var data = await (from p in db.products
                              join c in db.categories on p.categoryID equals c.id
                              select new ProductModel
                              {
                                  id = p.id,
                                  count = p.count,
                                  image = p.image,
                                  name = p.name,
                                  price = p.price,
                                  rate = p.rate,
                                  title = p.title,
                                  category = c.name
                              }).ToListAsync();
            return data;    
        }


    }
}
