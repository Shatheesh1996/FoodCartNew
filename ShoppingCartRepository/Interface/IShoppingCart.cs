using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Interface
{
  
      public interface IShoppingCart
    {
        List<ShoppingCartItem> GetShoppingCartItem(int id);
        string AddShoppingCartitem(Shoptocart Post_Obj);
        ShoptoCart_Response DeleteCartitem(int cart_id);
    }

}
