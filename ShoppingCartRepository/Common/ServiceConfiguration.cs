using System.Collections.Generic;

namespace FoodCart.Common
{
     public class ServiceConfiguration: IServiceConfiguration
    {
        private readonly Dictionary<string, string> _configValue = new Dictionary<string, string>();

        public string this[string key]
        {
            get 
            {
                if(_configValue.ContainsKey(key))
                {
                    return _configValue[key];
                }
                return string.Empty;
            }
            set
            {
                _configValue[key] = value;
            }
        }
    }
}
