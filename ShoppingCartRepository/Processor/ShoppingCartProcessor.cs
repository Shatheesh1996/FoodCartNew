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
        public ShoppingCartProcessor(IConnection connection)
        {
            _connection = connection;
        }
        public Food GetShoppingCartItem(int id)
        {
            SqlConnection Get_connection = new SqlConnection(_connection.GetConnection());
            SqlDataAdapter Get_adapter = new SqlDataAdapter("select name,Description,price,Instock,imageurl from food where FC_id = (select food_id from shoppingcart_item where userid = '" + id + "' )", Get_connection);
            DataTable get_table = new DataTable();
            Get_adapter.Fill(get_table);

            Food Getprop_obj = new Food()
            {
                Name = Convert.ToString(get_table.Rows[0]["name"]),
                Description = Convert.ToString(get_table.Rows[0]["name"]),
                Price = Convert.ToInt32(get_table.Rows[0]["price"]),
                Instock = Convert.ToInt32(get_table.Rows[0]["instock"]),
                imageurl = Convert.ToString(get_table.Rows[0]["imageurl"])
            };

            return Getprop_obj;

        }
    }
}
