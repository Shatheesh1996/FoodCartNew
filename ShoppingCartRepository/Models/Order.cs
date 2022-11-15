using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Models
{
   public class Order
    {
        public int pincode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public DateTime ordereddate { get;  }
        public int UserId { get; set; }


    }
}
