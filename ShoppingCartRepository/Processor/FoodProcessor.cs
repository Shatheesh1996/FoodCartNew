using Microsoft.Extensions.Logging;
using ShoppingCartRepository.Common;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ShoppingCartRepository.Processor
{
    public class FoodProcessor : IFood
    {
        public readonly IConnection _connection;
        public readonly ILogger<FoodProcessor> _logger;

        public FoodProcessor(IConnection connection, ILogger<FoodProcessor> logger)

        {
            _connection = connection;
            _logger = logger;
        }

        public List<Food> GetFood()
        {
            _logger.LogDebug("Executing GetFood");
            List<Food> foodList = new List<Food>();
            try
            {
                SqlConnection Get_connection = new SqlConnection(_connection.GetConnection());
                SqlDataAdapter Get_adapter = new SqlDataAdapter("select name,price,instock from Food", Get_connection);
                DataTable dataTable = new DataTable();
                Get_adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var food = new Food()
                        {
                            Name = Convert.ToString(dataTable.Rows[i]["name"]),
                            Price = Convert.ToInt32(dataTable.Rows[i]["price"]),
                            Instock = Convert.ToInt32(dataTable.Rows[i]["instock"]),
                        };
                        foodList.Add(food);
                    }
                }
                else
                {
                    _logger.LogError(ErrorMessages.Food_Data_Not_Available);
                    throw new FoodCartException(ErrorCodes.Food_Data_Not_Available, ErrorMessages.Food_Data_Not_Available);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "GetFood Processor Exception");
            }
            return foodList;
        }
    }
}
