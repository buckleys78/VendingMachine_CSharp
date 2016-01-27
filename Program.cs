using static System.Console;
using System.Diagnostics;

// using C# v6.0
// assignment #5 - LINQ and Collections
// Author: Steve Buckley

namespace SimpleVendingMachine {
    class Program {
        static void Main(string[] args) {
            CoinBox coinBox = new CoinBox();
            CanRack vendingMachine = new CanRack();
            PurchasePrice priceOfOneSoda = new PurchasePrice(0.35M);
            bool purchasingAnotherSoda = true;

            if (args.Length > 0) {
                ProcessCommandLinePurchase(args, ref vendingMachine, priceOfOneSoda);
                ReadKey();
                return;
            }

            while (purchasingAnotherSoda) {
                decimal totalAmountInserted = 0;
                decimal amountShort = 0;

                WriteLine("Welcome to the .NET C# Soda Vending Machine");
                WriteLine(vendingMachine.DisplayCanRack());
                Write($"Please insert {priceOfOneSoda.Price} cents.\n");
                Write("Enter your coins as one or more single letters separated by spaces, \n N(ickel), D(ime), Q(uarter), H(alfDollar): ");

                do {
                    string userResponse = ReadLine();
                    coinBox = AddCoinsToCoinBoxFromListOfCoins(userResponse, coinBox);
                    totalAmountInserted += AmountInsertedFromListOfCoins(userResponse);
                    amountShort = priceOfOneSoda.PriceInDollars - totalAmountInserted;
                    if (amountShort > 0) {
                        Write($"Please insert at least {amountShort:C} more: ");
                    }
                } while (totalAmountInserted < priceOfOneSoda.PriceInDollars);

                WriteLine($"You have inserted {totalAmountInserted:C}\n\n");
                bool selectionMade = false;
                Flavor selectedFlavor = Flavor.LEMON;
                do {
                    WriteLine(vendingMachine.ConsoleSelectionPrompt());
                    string userSelection = ReadLine();
                    selectionMade = vendingMachine.StocksThisFlavor(userSelection, ref selectedFlavor);
                    if (selectionMade) {
                        if (vendingMachine.IsEmpty(selectedFlavor)) {
                            WriteLine($"Sorry, we are out of {selectedFlavor}, please make a different choice.\n");
                            selectionMade = false;
                        }
                    } else {
                        WriteLine($"{userSelection} is not a recognized flavor. Please choose again.\n");
                    }
                } while (!selectionMade);

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
            WriteLine($"\nThe coin box contains \n{coinBox.ToString()}");
            WriteLine($" and has a total value of {coinBox.ValueOf:C}.");
            WriteLine(" (ignores change returned) ToDo");
            ReadKey();
        }

        private static CoinBox AddCoinsToCoinBoxFromListOfCoins(string listOfCoins, CoinBox coinBox) {
            if (listOfCoins.Length > 0) {
                string[] coins = listOfCoins.Split(' ');
                foreach (var coinAbbrev in coins) {
                    coinBox.Deposit(new Coin(coinAbbrev));
                }
            }
            return coinBox;
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

        private static void ProcessCommandLinePurchase(string[] args, ref CanRack vendingMachine, PurchasePrice priceOfOneSoda) {
            if (args.Length < 2 ) {
                WriteLine("Invalid Command line parameters: must be in the form 'flavor coin1 [coin2]...");
                return;
            }

            Flavor flavor = Flavor.LEMON;
            bool isValidFlavor = vendingMachine.StocksThisFlavor(args[0], ref flavor);
            if (!isValidFlavor) {
                WriteLine($"{args[0]} is not a valid flavor name.");
                return;
            }

            decimal valueOfCoins = 0;
            for (int i=1; i<args.Length; i++) {
                valueOfCoins += new Coin(args[i]).ValueOf;
            }

            decimal amountOfChange = valueOfCoins - priceOfOneSoda.PriceInDollars;
            if (amountOfChange < 0) {
                WriteLine($"You are short {-amountOfChange:C}.");
            } else {
                vendingMachine.RemoveACanOf(flavor);
                WriteLine($"Thanks. Here is your {flavor} soda.\n");
                if (amountOfChange > 0) {
                    WriteLine($"and here is your change of {amountOfChange:C}.");
                }
            }
        }
    }
}
