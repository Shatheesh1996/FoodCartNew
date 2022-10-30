using Microsoft.Extensions.DependencyInjection;
using ShoppingCartRepository.Interface;
using ShoppingCartRepository.Processor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Common
{
    public static class ServiceCollection
    {
        public static void AddProcessor(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCart, ShoppingCartProcessor>();
            services.AddScoped<IConnection, Connection>();
        }
    }
}
