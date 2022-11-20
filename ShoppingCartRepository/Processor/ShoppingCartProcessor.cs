using Microsoft.Extensions.Logging;
using ShoppingCartRepository.Common;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
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
        public List<ShoppingCartItem> GetShoppingCartItem(int id)
        {
            _logger.LogDebug(1, "Executing GetShoppingCartItem processor");
            List<ShoppingCartItem> Food_details = new List<ShoppingCartItem>();
            try
            {
                SqlConnection Get_connection = new SqlConnection(_connection.GetConnection());
                SqlDataAdapter Get_adapter = new SqlDataAdapter("select name,Description,price,Instock,imageurl from food where FC_id in (select food_id from shoppingcart_item where userid = '" + id + "' )", Get_connection);
                DataTable dataTable = new DataTable();
                Get_adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var food = new ShoppingCartItem()
                        {
                            Name = Convert.ToString(dataTable.Rows[i]["name"]),
                            Description = Convert.ToString(dataTable.Rows[i]["name"]),
                            Price = Convert.ToInt32(dataTable.Rows[i]["price"]),
                            Instock = Convert.ToInt32(dataTable.Rows[i]["instock"]),
                            imageurl = Convert.ToString(dataTable.Rows[i]["imageurl"])
                        };
                        Food_details.Add(food);
                    }
                }
                else
                {
                    _logger.LogError(ErrorMessages.Shopping_Cart_Data_Not_Available);
                    throw new FoodCartException(ErrorCodes.Shopping_Cart_Data_Not_Available, ErrorMessages.Shopping_Cart_Data_Not_Available);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetShoppingCartItem Processor Exception");
            }
            return Food_details;
        }

        public string AddShoppingCartitem(Shoptocart Post_Obj)
        {
            _logger.LogDebug(2, "Executing AddShoppingCartitem processor");
            try
            {


                SqlConnection Post_connection = new SqlConnection(_connection.GetConnection());
                SqlCommand Post_cmd = new SqlCommand("insert into shoppingcart_item(Userid,food_id,Quantity, Price)values( '" + Post_Obj.User_id + "', '" + Post_Obj.Food_id + "', '" + Post_Obj.Quantity + "', '"+Post_Obj.Price +"')", Post_connection);
                Post_connection.Open();
                int i = Post_cmd.ExecuteNonQuery();
                Post_connection.Close();
                if (i > 0)
                {
                    return "request success";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddShoppingCartitem processor exception");
            }
            return string.Empty;
        }

        public ShoptoCart_Response DeleteCartitem(int cart_id)
        {
            _logger.LogDebug(3, "Executing DeleteCartitem processor");
            ShoptoCart_Response del_prop = new ShoptoCart_Response();
            try
            {

                SqlConnection connection = new SqlConnection(_connection.GetConnection());
                SqlCommand cmd = new SqlCommand("delete from shoppingcart_item where id = '" + cart_id + "'", connection);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                {

                    del_prop.status_message = "cart deleted successfully";

                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "DeleteCartitem processor exception");
            }
            return del_prop;

        }

    }
}