using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShoppingCartRepository.Common;
using ShoppingCartRepository.Interface;
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
        public OrderDetailController(IConfiguration configuration, IOrderDetails OrderDetails)
        {
            _configuration = configuration;
            _OrderDetails = OrderDetails;
        }
        [HttpPost]
        [Route("AddOrderDetail")]
        public string AddOrderDetail()
        {
            return AddOrderDetail();
            

        }
    }
}
