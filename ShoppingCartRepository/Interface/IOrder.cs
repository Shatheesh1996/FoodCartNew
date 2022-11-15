using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Interface
{
   public interface IOrder
    {
        Order_Response AddOrder(Order order_prop);
    }
}
