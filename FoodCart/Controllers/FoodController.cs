using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
using System.Collections.Generic;

namespace FoodCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public readonly IFood _food;
        public readonly ILogger<FoodController> _logger;
        public FoodController(IFood food, ILogger<FoodController> logger)
        {
            _food = food;
            _logger = logger;
        }
        [HttpGet]
        public List<Food> GetFood()
        {
            _logger.LogDebug(1, "Executing GetFood ");
            return _food.GetFood();
        }
    }
}
