using Microsoft.Extensions.Logging;
using ShoppingCartRepository.Common;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ShoppingCartRepository.Processor
{
    public class ShoppingCartProcessor : IShoppingCart
    {
        private readonly IConnection _connection;
        private readonly ILogger<ShoppingCartProcessor> _logger;
        public ShoppingCartProcessor(IConnection connection, ILogger<ShoppingCartProcessor> logger)
        {
            _connection = connection;
            _logger = logger;
        }
        public Food GetShoppingCartItem(int id)
        {
            _logger.LogDebug(1, "Executing GetShoppingCartItem processor");
            Food food = new Food();
            try
            {
                SqlConnection Get_connection = new SqlConnection(_connection.GetConnection());
                SqlDataAdapter Get_adapter = new SqlDataAdapter("select name,Description,price,Instock,imageurl from food where FC_id = (select food_id from shoppingcart_item where userid = '" + id + "' )", Get_connection);
                DataTable dataTable = new DataTable();
                Get_adapter.Fill(dataTable);

                if(dataTable.Rows.Count > 0)
                {
                    food.Name = Convert.ToString(dataTable.Rows[0]["name"]);
                    food.Description = Convert.ToString(dataTable.Rows[0]["name"]);
                    food.Price = Convert.ToInt32(dataTable.Rows[0]["price"]);
                    food.Instock = Convert.ToInt32(dataTable.Rows[0]["instock"]);
                    food.imageurl = Convert.ToString(dataTable.Rows[0]["imageurl"]);
                }
                else
                {
                    _logger.LogError("Food data not available");
                    throw new FoodCartException(ErrorCodes.Food_Data_Not_Available, ErrorMessages.Food_Data_Not_Available);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "GetShoppingCartItem Processor Exception");
            }
            return food;
        }

        public string AddCart(Shoptocart Post_Obj)
        {
            SqlConnection Post_connection = new SqlConnection(_connection.GetConnection());
            SqlCommand Post_cmd = new SqlCommand("insert into shoppingcart_item(Userid,food_id,Quantity)values( '" + Post_Obj.User_id + "', '" + Post_Obj.Food_id + "', '" + Post_Obj.Quantity + "')", Post_connection);
            Post_connection.Open();
            int i = Post_cmd.ExecuteNonQuery();
            Post_connection.Close();
            if (i > 0)
            {
                return "request success";
            }
            else
            {
                return "request failed";
            }

        }
        
        public ShoptoCart_Response DeleteCart(int cart_id)
        {
            ShoptoCart_Response del_prop = new ShoptoCart_Response();
            SqlConnection connection = new SqlConnection(_connection.GetConnection());
            SqlCommand cmd = new SqlCommand("delete from shoppingcart_item where id = '" + cart_id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
           
            if (i > 0)
            {
                
                del_prop.status_message = "cart deleted successfully";

            }
            else
            { 
                del_prop.status_message = "cart request unsuccesfull";

            }
            return del_prop;

        }

    }
}