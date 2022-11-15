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
    class OrderProcessor : IOrder
    {
        public readonly IConnection _connection;
        public readonly ILogger<IOrder> _logger;
        public OrderProcessor(IConnection connection, ILogger<IOrder> logger)
        {
            _connection = connection;
            _logger = logger;
        }
        public Order_Response AddOrder(Order order_prop)
        {
            _logger.LogDebug(1, "Executing AddOrder processor");
            Order_Response Response = new Order_Response();
            try
            {
                SqlConnection connection = new SqlConnection(_connection.GetConnection());
                SqlCommand cmd = new SqlCommand("insert into orders (pincode,Address,City,Country,orderplacedtime,userid) values('" + order_prop.pincode + "', '" + order_prop.Address + "', '" + order_prop.City + "','" + order_prop.Country + "', '"+DateTime.Now+"','" + order_prop.UserId + "')", connection);
               
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    Response.status_message = "submitted succesfully";

                }
                else

                {
                    Response.status_message = " failed to add order";
                }
            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddOrder processor exception");
            }


            return Response;

        }

    
    }
}



