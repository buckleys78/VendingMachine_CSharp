using static System.Console;

// using C# v6.0
// Author: Steve Buckley

namespace SimpleVendingMachine {
    class Program {
        static void Main(string[] args) {
            PurchasePrice priceOfOneSoda = new PurchasePrice(35);
            int totalAmountInserted = 0;

            WriteLine("Welcome to the .NET C# Soda Vending Machine");
            Write($"Please insert {priceOfOneSoda.Price} cents: ");

            while (totalAmountInserted < priceOfOneSoda.Price) {
                string userResponse = ReadLine();
                int amountInsertedThisTime = 0;
                int.TryParse(userResponse, out amountInsertedThisTime);
                totalAmountInserted += amountInsertedThisTime;
                int amountShort = priceOfOneSoda.Price - totalAmountInserted;
                if (amountShort > 0) {
                    Write($"Please insert at least {amountShort} cents more: ");
                }
            }

            WriteLine($"You have inserted {totalAmountInserted} cents.");
            WriteLine("Thanks. Here is your soda.");
            ReadKey();
        }
    }
}
