using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCart.Common
{
    public interface IServiceConfiguration
    {
         string this[string key] { get; set; }
    }
}
