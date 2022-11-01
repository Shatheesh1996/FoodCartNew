
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
            _logger.LogDebug(1, "NLog injected into HomeController");
        }
        [HttpPost]
        [Route("AddCart")]
        public string AddCart()
        {
            return AddCart();
        }

        [HttpGet]
        [Route("GetShoppingCartItem/{id}")]
        public Food GetShoppingCartItem(int id)
        {
            _logger.LogDebug(1, "Executing GetShoppingCartItem");
            var food = _shoppingCart.GetShoppingCartItem(id);
            return food;
        }

        [HttpDelete]
        [Route("DeleteCart/{cart_id}")]
        public string DeleteCart(int cart_id)
        {
            return DeleteCart(cart_id);
        }
    }
}


