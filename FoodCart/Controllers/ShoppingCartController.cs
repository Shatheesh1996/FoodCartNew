
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IShoppingCart _shoppingCart;
        private readonly ILogger<ShoppingCartController> _logger;
        public ShoppingCartController(IConfiguration configuration,
            IShoppingCart shoppingCart, ILogger<ShoppingCartController> logger)
        {
            _configuration = configuration;
            _shoppingCart = shoppingCart;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into ShoppingCartController");
        }
        [HttpPost]
        [Route("AddShoppingCartitem")]
        public string AddShoppingCartitem(Shoptocart Post_Obj)
        {
            _logger.LogDebug(2, "Executing AddShoppingCartitem ");
            return _shoppingCart.AddShoppingCartitem(Post_Obj);
        }

        [HttpGet]
        [Route("GetShoppingCartItem/{id}")]
        public List<ShoppingCartItem> GetShoppingCartItem(int id)
        {
            _logger.LogDebug(1, "Executing GetShoppingCartItem");
            List<ShoppingCartItem> cart_item = _shoppingCart.GetShoppingCartItem(id);
            return cart_item;
        }

        [HttpDelete]
        [Route("DeleteCartitem /{cart_id}")]
        public ShoptoCart_Response DeleteCartitem(int cart_id)
        {
            _logger.LogDebug(3, "Executing DeleteCartitem ");
            return _shoppingCart.DeleteCartitem(cart_id);
        }
    }
}


