using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Models
{
    public class Orderdetails
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int Amount { get; set; }
        public int  Quantity { get; set; }
        public string FoodName { get; set; }

    }
}
