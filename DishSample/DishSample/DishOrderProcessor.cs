using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DishSample
{
    public class DishOrderProcessor
    {
        private readonly IDishInputParser _dishCommandLineParser;

        public DishOrderProcessor(IDishInputParser dishInputParser)
        {
            _dishCommandLineParser = dishInputParser;
        }

        public string ProcessDishOrder()
        {
            // Morning Dishes
            var morningDishes = new Dictionary<int, string>
            {
                {1, "eggs"},
                {2, "toast"},
                {3, "coffee"},
                {4, "error"}
            };

            // Night dishes
            var nightDishes = new Dictionary<int, string>
            {
                {1, "steak"},
                {2, "potato"},
                {3, "wine"},
                {4, "cake"}
            };

            try
            {
                var outPutString = new StringBuilder();
                var coffeeCount = _dishCommandLineParser    //coffee count for morning (Business Rule #7)
                                        .OrderNumbers
                                        .Count(orderNumber => orderNumber == DishConstants.CoffeeDishType && _dishCommandLineParser.TimeOfTheDay.ToLower().Equals(DishConstants.Morning));

                var potatoCount = _dishCommandLineParser    // potato count for night (Business Rule #8)
                                        .OrderNumbers
                                        .Count(orderNumber => orderNumber == DishConstants.PotatoDishType && _dishCommandLineParser.TimeOfTheDay.ToLower().Equals(DishConstants.Night));

                // Sort the Order Numbers 
                _dishCommandLineParser.OrderNumbers.Sort();

                var timeOfTheDay = _dishCommandLineParser.TimeOfTheDay.ToLower();
                var isCoffeePrinted = false;
                var isPotatoPrinited = false;

                foreach (var orderNumber in _dishCommandLineParser.OrderNumbers)
                {
                    var dishName = "";
                    if (timeOfTheDay.Equals(DishConstants.Morning))
                    {
                        dishName = orderNumber >= 4 ? DishConstants.Error : morningDishes[orderNumber]; //No 4th Entry for morning

                        if (orderNumber == DishConstants.CoffeeDishType && isCoffeePrinted == false)
                        {
                            if(coffeeCount > 1)
                                dishName = string.Format("{0}(x{1})", dishName, coffeeCount);
                            
                            outPutString.Append(string.Format("{0}{1}", dishName, ","));
                            isCoffeePrinted = true;
                        }
                        else if (orderNumber != DishConstants.CoffeeDishType)
                        {
                            if (outPutString.ToString().Contains(dishName))
                            {
                                outPutString.Append(string.Format("{0}{1}", DishConstants.Error, ","));
                                break;
                            }
                            outPutString.Append(string.Format("{0}{1}", dishName, ","));
                        }
                    }
                    else
                    {     // For night dishes
                        dishName = orderNumber > 4 ? DishConstants.Error : nightDishes[orderNumber]; //can enter up to 4 entries

                        if (orderNumber == DishConstants.PotatoDishType && isPotatoPrinited == false)
                        {
                            if(potatoCount > 1)
                                dishName = string.Format("{0}(x{1})", dishName, potatoCount);

                            outPutString.Append(string.Format("{0}{1}", dishName, ","));
                            isPotatoPrinited = true;
                        }
                        else if (orderNumber != DishConstants.PotatoDishType)
                        {
                            if (outPutString.ToString().Contains(dishName))
                            {
                                outPutString.Append(string.Format("{0}{1}", DishConstants.Error, ","));
                                break;
                            }
                            outPutString.Append(string.Format("{0}{1}", dishName, ","));
                        }
                    }
                }

                if (outPutString.Length > 0)
                    return outPutString.ToString().Substring(0, outPutString.Length - 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in processing dish orders: {0}", ex);
            }

            return string.Empty;
        }

        public void DisplayDishOrders(string orderOutPutString)
        {
            Console.WriteLine("\nOutput: {0}\n",orderOutPutString);
        }
    }
}
