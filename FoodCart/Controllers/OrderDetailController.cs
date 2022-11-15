using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingCartRepository.Common;
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
    public class OrderDetailController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IOrderDetails _OrderDetails;
        public readonly ILogger<OrderDetailController> _logger;
        public OrderDetailController(IConfiguration configuration, IOrderDetails OrderDetails, ILogger<OrderDetailController> logger)
        {
            _configuration = configuration;
            _OrderDetails = OrderDetails;
            _logger = logger;
        }
        [HttpPost]
        [Route("AddOrderDetail")]
        public Orderdetails_response AddOrderDetail(List<Orderdetails> orderdetails)
        {
            _logger.LogDebug(1, "Executing AddOrderDetail ");
           return _OrderDetails.AddOrderDetail(orderdetails);
        }
    }
}
