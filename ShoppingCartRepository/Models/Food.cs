using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Models
{
    public class Food
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Instock { get; set; }
        public string imageurl { get; set; }
    }
}
