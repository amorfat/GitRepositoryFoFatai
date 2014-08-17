using System;

namespace DishSample
{
    //Dish Type   morning         night
    //1 (entrée)  eggs            steak
    //2 (side)    Toast           potato
    //3 (drink)   coffee          wine
    //4 (dessert) Not Applicable  cake
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Please enter the dish orders: ");
                    Console.WriteLine("**********************************************\n");

                    var dishInputString = Console.ReadLine();

                    var dishCommandLineParser = new DishInputParser(dishInputString);
                    if (dishCommandLineParser.Validate())
                        dishCommandLineParser.Process();

                    var dishOrderProcessor = new DishOrderProcessor(dishCommandLineParser);
                    var outputOrderString = dishOrderProcessor.ProcessDishOrder();
                    dishOrderProcessor.DisplayDishOrders(outputOrderString);

                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Hit any key to Continue..\n");
                    Console.ReadLine();
                }
                catch (DishException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problem in parsing the input string: {0}", ex);
                }
            }
        }
    }
}
