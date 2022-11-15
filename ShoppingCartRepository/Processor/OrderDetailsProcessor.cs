using Microsoft.Extensions.Logging;
using ShoppingCartRepository.Common;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            _logger.LogDebug(1,"Executing AddOrderDetail processor");
            Orderdetails_response response = new Orderdetails_response(); 
            try
            {
               
                if (order_Properties != null && order_Properties.Count > 0)
                {
                    foreach (var orderproperty in order_Properties)
                    {
                        SqlConnection connection = new SqlConnection(_connection.GetConnection());
                        SqlCommand cmd = new SqlCommand("insert into Orderdetail(order_id,food_id,amount,quantity) values ('" + orderproperty.OrderId + "','" + orderproperty.FoodId + "','" + orderproperty.Amount + "','" + orderproperty.Quantity + "')", connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    response.status_message = "OrderDetails request success";
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp,"AddOrderDetail processor exception");
            }
            return response;
                
            } 
    }
}
