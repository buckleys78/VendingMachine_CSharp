using static System.Console;
using System.Diagnostics;

// using C# v6.0
// assignment #4 - Controls
// Author: Steve Buckley

namespace SimpleVendingMachine {
    class Program {
        static void Main(string[] args) {
            CanRack vendingMachine = new CanRack();
            PurchasePrice priceOfOneSoda = new PurchasePrice(35);
            bool purchasingAnotherSoda = true;

            while (purchasingAnotherSoda) {
                decimal totalAmountInserted = 0;
                decimal amountShort = 0;

                WriteLine("Welcome to the .NET C# Soda Vending Machine");
                WriteLine(vendingMachine.DisplayCanRack());
                Write($"Please insert {priceOfOneSoda.Price} cents.\n");
                Write("Enter your coins as one or more single letters separated by spaces, \n N(ickel), D(ime), Q(uarter), H(alfDollar): ");

                while (totalAmountInserted < priceOfOneSoda.PriceInDollars) {
                    string userResponse = ReadLine();
                    totalAmountInserted += AmountInsertedFromListOfCoins(userResponse);
                    amountShort = priceOfOneSoda.PriceInDollars - totalAmountInserted;
                    if (amountShort > 0) {
                        Write($"Please insert at least {amountShort:C} more: ");
                    }
                }

                WriteLine($"You have inserted {totalAmountInserted:C}\n\n");
                bool selectionMade = false;
                Flavor selectedFlavor = Flavor.LEMON;
                while (!selectionMade) {
                    WriteLine(vendingMachine.ConsoleSelectionPrompt());
                    string userSelection = ReadLine();
                    selectionMade = vendingMachine.StocksThisFlavor(userSelection, ref selectedFlavor);
                    if (selectionMade) {
                        if (vendingMachine.IsEmpty(selectedFlavor)) {
                            WriteLine($"Sorry, we are out of {selectedFlavor}, please make a different choice.\n");
                            selectionMade = false;
                        }
                    } else {
                        WriteLine($"{userSelection} is not a recognized flavor. Please chose again.\n");
                    }
                }

                vendingMachine.RemoveACanOf(selectedFlavor);
                WriteLine($"Thanks. Here is your {selectedFlavor} soda.");
                if (amountShort < 0) {
                    WriteLine($"and here is your change of {-amountShort:C}.");
                }

                WriteLine(vendingMachine.DisplayCanRack());

                if (vendingMachine.IsEmpty()) {
                    WriteLine("This vending machine is empty. Please visit your nearest Costco if you are still thirsty.");
                    purchasingAnotherSoda = false;
                    ReadKey();
                } else {
                    WriteLine("Press 'x' to exit or any other key to purchase another soda.");
                    purchasingAnotherSoda = ReadKey().Key.ToString().ToLower() != "x";
                }
            }
        }

        private static decimal AmountInsertedFromListOfCoins(string listOfCoins) {
            if (listOfCoins.Length == 0) return 0;
            string[] coins = listOfCoins.Split(' ');
            decimal sum = 0;
            foreach (var coinAbbrev in coins) {
                sum += new Coin(coinAbbrev).ValueOf;
            }
            return sum;
        }
    }
}
