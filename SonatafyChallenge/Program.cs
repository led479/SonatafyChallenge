using System;
using System.Collections.Generic;

namespace SonatafyChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var salesReceipt = new SalesReceipt
                {
                    Items = new List<Item>()
                };

                var userSelection = "";

                while (userSelection != "2")
                {
                    Console.WriteLine("\nWhat would you like to do? (Input the following number to proceed):");

                    Console.WriteLine(" 1 - Add item to shopping basket");
                    Console.WriteLine(" 2 - Print Sales Receipt and finish\n");

                    userSelection = Console.ReadLine();

                    if (userSelection == "1")
                    {
                        Console.WriteLine("\nPlease write the item that you would like to include in the following pattern:\n" +
                            "(Prepend Imported to the name if it is an imported item)\n\n" +
                            "   {Quantity} {Name} at {Value}\n\n");

                        var userItemInput = Console.ReadLine();

                        List<Item> newItems;
                        if (ConsoleInputHelper.TryCreateItemFromConsoleInput(userItemInput, out newItems))
                        {
                            salesReceipt.Items.AddRange(newItems);
                            Console.WriteLine($"\nInputted item has been successfully added to the shopping basket");

                        }
                        else
                            Console.WriteLine("\nThe item isn't written in the correct pattern, please make sure to follow the pattern.");
                    }
                }

                Console.WriteLine("\n============ SALES RECEIPT ============");
                Console.WriteLine(salesReceipt.GetStringRepresentation());

            } catch (ApplicationException ex)
            {
                Console.WriteLine($"\n\nAn error has occurred! Error description: {ex.Message}.");
            }
        }
    }
}
