using static System.Console;
using System.Diagnostics;

// using C# v6.0
// assignment #2 - Classes
// Author: Steve Buckley

namespace SimpleVendingMachine {
    class Program {
        static void Main(string[] args) {
            CanRack vendingMachine = new CanRack();
            PurchasePrice priceOfOneSoda = new PurchasePrice(35);
            int totalAmountInserted = 0;
            int amountShort =0;

            Debug.WriteLine("This goes in the debug window.");
            Debug.WriteLine("To make this window visible, use menu item.");
            Debug.WriteLine("Debug\\Windows\\Output");


            WriteLine("Welcome to the .NET C# Soda Vending Machine");
            Write($"Please insert {priceOfOneSoda.Price} cents: ");

            while (totalAmountInserted < priceOfOneSoda.Price) {
                string userResponse = ReadLine();
                int amountInsertedThisTime = 0;
                int.TryParse(userResponse, out amountInsertedThisTime);
                totalAmountInserted += amountInsertedThisTime;
                amountShort = priceOfOneSoda.Price - totalAmountInserted;
                if (amountShort > 0) {
                    Write($"Please insert at least {amountShort} cents more: ");
                }
            }

            WriteLine($"You have inserted {totalAmountInserted} cents.");
            string selectedFlavor = "Lemon";
            vendingMachine.RemoveACanOf(selectedFlavor);
            WriteLine($"Thanks. Here is your {selectedFlavor} soda.");
            if (amountShort < 0) {
                WriteLine($"and here is your change of {-amountShort} cents.");
            }
            ReadKey();
        }
    }
}
