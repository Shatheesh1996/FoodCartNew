using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
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
        public readonly ILogger<OrderController> _logger;

        public readonly IOrder _order;
        public OrderController(IConfiguration configuration, IOrder order, ILogger<OrderController> logger)
        {
            _configuration = configuration;
            _order = order;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddOrder")]
        public Order_Response AddOrder(Order order_properties)
        {
            _logger.LogDebug(1, "Executing AddOrder");

            return _order.AddOrder(order_properties);
        }

    }
}
