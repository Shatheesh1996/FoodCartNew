using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShoppingCartRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public readonly IOrder _order;
        public OrderController(IConfiguration configuration, IOrder order)
        {
            _configuration = configuration;
            _order = order;
        }

        [HttpPost]
        [Route("AddOrder")]
        public string AddOrder()
        {
            return AddOrder();
        }

    }
}
