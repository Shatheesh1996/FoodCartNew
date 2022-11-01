using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartRepository.Common
{
    public class FoodCartException: Exception
    {
        public readonly int ErrorCode = 0;
        public FoodCartException(int errorCode, string message): base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
