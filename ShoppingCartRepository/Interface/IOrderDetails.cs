using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Interface
{
    public interface IOrderDetails
    {
        Orderdetails_response AddOrderDetail(List<Orderdetails> order_Properties);
    }
}
