using clothes_backend.Entities.Cart;

namespace clothes_backend.Service.Client
{
    public interface ICart
    {
        public Task<int> AddCartAsync(CartModel model);
    }
    public class CartRepo : ICart
    {
        protected readonly Context db;
        public CartRepo(Context db)
        {
            this.db = db;
        }
        public async Task<int> AddCartAsync(CartModel model)
        {
            var newCart = new Cart
            {
                firstName = model.firstName,
                lastName = model.lastName,
                address = model.address,
                phoneNumber = model.phoneNumber,
                color = model.color,
                size = model.size,
                number = model.number,
                product = model.product,
                status = Status.dangGiao
            };
            var s = db.Carts.Add(newCart);
            await db.SaveChangesAsync();
            return newCart.id;
        }
    }
}
