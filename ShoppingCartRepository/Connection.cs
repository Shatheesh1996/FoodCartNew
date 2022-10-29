using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ShoppingCartRepository
{
    public  class Connection
    {
        private  readonly IConfiguration _configuration;
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  Connection()
        {

        }
        public  string GetConnection()
        {
              return _configuration.GetConnectionString("AppConnection").ToString();
        }
    }
}
