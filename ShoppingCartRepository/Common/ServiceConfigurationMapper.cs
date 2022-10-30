using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCart.Common
{
    public static class ServiceConfigurationMapper
    {
        public static ServiceConfiguration GetServiceConfiguration(IConfiguration configuration)
        {
            ServiceConfiguration config = new ServiceConfiguration();
            config["AppConnection"] = configuration.GetConnectionString("AppConnection").ToString();
            return config;
        }
    }
}
