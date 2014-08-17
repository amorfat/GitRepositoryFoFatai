using System.Collections.Generic;

namespace DishSample
{
    public class DishInputParser : IDishInputParser
    {
        readonly string _commaSeparatedOrderEntries = string.Empty;
        public string TimeOfTheDay { get; set; }
        public List<int> OrderNumbers { get; set; }

        public DishInputParser(string commanSeparatedOrderEntries)
        {
            _commaSeparatedOrderEntries = commanSeparatedOrderEntries;
        }

        public bool Validate()
        {
            if (!(_commaSeparatedOrderEntries.ToLower().Contains("night") ||
                  _commaSeparatedOrderEntries.ToLower().Contains("morning")))
                throw new DishException("Input string must have a valid time of the day as 'morning' or 'night'");
          
            if (!_commaSeparatedOrderEntries.Contains(","))
                throw new DishException("Input string must have a comma separated orders");

            return true;
        }

        /// <summary>
        /// Process DishEntries.
        /// The first item should be - Time of the day. The rest is comma separated order numbers
        /// </summary>
        public void Process()
        {
            var allOrders = new List<int>();
            var splittedOrderEntries = _commaSeparatedOrderEntries.Split(',');

            // Set time of day
            TimeOfTheDay = splittedOrderEntries[0];

            // Skip the first entry
            for (var i = 1; i < splittedOrderEntries.Length; i++)
            {
                var orderEntry = 0;
                int.TryParse(splittedOrderEntries[i], out orderEntry);
                allOrders.Add(orderEntry);
            }

            OrderNumbers = allOrders;
        }
    }
}
