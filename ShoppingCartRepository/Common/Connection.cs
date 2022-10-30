using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using FoodCart.Common;
using Microsoft.VisualBasic;

namespace ShoppingCartRepository.Common
{
    public class Connection: IConnection
    {
        private readonly IServiceConfiguration _configuration;
        public Connection(IServiceConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            return _configuration["AppConnection"];
        }
    }
}
