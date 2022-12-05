using clothes_backend.Service;
using clothes_backend.Service.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clothes_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        protected readonly ICart cartService;

        public CartsController(ICart cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(CartModel model)
        {
            try
            {
                var newCart = await cartService.AddCartAsync(model);
                return Ok(newCart);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
