using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Instock { get; set; }
        public int Price { get; set; }
    }
}
