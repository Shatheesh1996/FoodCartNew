using FoodCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public ShoppingCartController(IConfiguration configuration,
            IShoppingCart shoppingCart)
        {
            _configuration = configuration;
            _shoppingCart = shoppingCart;
        }
        [HttpPost]
        [Route("AddCart")]
        public string AddCart(Request_body_property RequestObj)
        {
            SqlConnection Post_connection = new SqlConnection(_configuration.GetConnectionString("AppConnection").ToString());
            SqlCommand Post_cmd = new SqlCommand("insert into shoppingcart_item(Userid,food_id,Quantity)values( '" + RequestObj.User_id + "', '" + RequestObj.Food_id + "', '" + RequestObj.Quantity + "')", Post_connection);
            Post_connection.Open();
            int i = Post_cmd.ExecuteNonQuery();
            Post_connection.Close();
            if (i > 0)
            {
                return "request success";
            }
            else
            {
                return "request failed";
            }
        }
        [HttpGet]
        [Route("GetShoppingCartItem/{id}")]
        public Food GetShoppingCartItem(int id)
        {
            var food = _shoppingCart.GetShoppingCartItem(id);
            return food;
        }
    }
}


