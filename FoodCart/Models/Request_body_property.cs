using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCart.Models
{
    public class Request_body_property
    {
        public int Food_id { get; set; }
        public int Quantity { get; set; }
        public int User_id { get; set; }
    }
}
