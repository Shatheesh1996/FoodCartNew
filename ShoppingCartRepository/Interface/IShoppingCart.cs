using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Interface
{
  
      public interface IShoppingCart
    {
        Food GetShoppingCartItem(int id);
        string AddCart(Shoptocart Post_Obj);
        ShoptoCart_Response DeleteCart(int cart_id);
    }

}
