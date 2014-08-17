using System;

namespace DishSample
{
    public class DishException: ApplicationException
    {
        public DishException(string errorMessage) : base(errorMessage)
        {
           
        }
    }
}
