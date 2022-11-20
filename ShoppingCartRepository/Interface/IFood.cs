using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Interface
{
    public interface IFood
    {
        List<Food> GetFood();
    }
}
