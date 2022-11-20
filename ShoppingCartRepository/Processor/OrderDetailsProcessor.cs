using Microsoft.Extensions.Logging;
using NLog.Filters;
using ShoppingCartRepository.Common;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ShoppingCartRepository.Processor
{
    class OrderDetailsProcessor : IOrderDetails
    {
        public readonly IConnection _connection;
        public readonly ILogger<OrderDetailsProcessor> _logger;


        public OrderDetailsProcessor(IConnection connection, ILogger<OrderDetailsProcessor> logger)

        {
            _connection = connection;
            _logger = logger;
        }
        public Orderdetails_response AddOrderDetail(List<Orderdetails> order_Properties)
        {
            _logger.LogDebug(1, "Executing AddOrderDetail processor");
            Orderdetails_response response = new Orderdetails_response();
            try
            {

                if (order_Properties != null && order_Properties.Count > 0)
                {
                    DataSet ds = new DataSet();
                    foreach (var orderproperty in order_Properties)
                    {
                        SqlConnection connection1 = new SqlConnection(_connection.GetConnection());
                        SqlDataAdapter da = new SqlDataAdapter("select id,Name,Instock  from Food", connection1);
                        da.Fill(ds);
                        var dt = ds.Tables[0];
                        List<Food> foodList = ds.Tables[0].AsEnumerable()
                            .Select(row => new Food
                            {
                                Id = row.Field<int>("ID"),
                                Name = row.Field<string>("Name"),
                                Instock = row.Field<int>("Instock")
                            }).ToList();
                        var inStock = foodList.FirstOrDefault(x => x.Name.Equals(orderproperty.FoodName, StringComparison.OrdinalIgnoreCase)).Instock - orderproperty.Quantity;
                        var foodId = foodList.FirstOrDefault(x => x.Name.Equals(orderproperty.FoodName, StringComparison.OrdinalIgnoreCase)).Id;
                        SqlConnection connection = new SqlConnection(_connection.GetConnection());
                        SqlCommand cmd = new SqlCommand("insert into Orderdetail(order_id,food_id,amount,quantity) values ('" + orderproperty.OrderId + "','" + foodId + "','" + orderproperty.Amount + "','" + orderproperty.Quantity + "');update food set Instock ='" + inStock + "' where id='" + foodId + "'", connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        foodList = null;
                        ds.Tables.Clear();
                        dt.Clear();
                    }
                    response.status_message = "OrderDetails request success";
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "AddOrderDetail processor exception");
            }
            return response;

        }
    }
}
