using System;
using static System.Console;

namespace SimpleVendingMachine {
    class Coin {
        public enum Denomination {
            SLUG = 0, NICKEL = 5, DIME = 10, QUARTER = 25, HALFDOLLAR = 50
        }

        // Constructor(s)
        public Coin() {
            Enumeral = Denomination.SLUG;
        }

        public Coin(Denomination coin) {
            Enumeral = coin;
        }

        public Coin(int coinValueInCents) {
            switch (coinValueInCents) {
                case 5:
                    Enumeral = Denomination.NICKEL;
                    break;
                case 10:
                    Enumeral = Denomination.DIME;
                    break;
                case 25:
                    Enumeral = Denomination.QUARTER;
                    break;
                case 50:
                    Enumeral = Denomination.HALFDOLLAR;
                    break;
                default:
                    // ToDo throw exception
                    Enumeral = Denomination.SLUG;
                    break;
            }
        }

        public Coin(string coinName) {
            Denomination coinType = Denomination.SLUG;
            if (coinName.Length == 1) {
                coinType = AbbrevNameToFullName(coinName);
            } else {
                Enum.TryParse(coinName.ToUpper(), out coinType);
            }
            Enumeral = coinType;
        }

        // Properties
        public Denomination Enumeral {get; set;}

        public decimal ValueOf {
            get {
                return (int)Enumeral / 100M;
            }
        }

        public override string ToString() {
            return Enumeral.ToString();
        }

        public void CoinUnitTests() {
            Coin coinTest1 = new Coin();
            WriteLine($"coinTest1 expects 'SLUG', result = {coinTest1.ToString()}.");

            Coin coinTest2 = new Coin(Coin.Denomination.HALFDOLLAR);
            WriteLine($"coinTest2 expects 'HALFDOLLAR', result = {coinTest2.ToString()}.");

            Coin coinTest3 = new Coin("Dime");
            WriteLine($"coinTest3 expects 'DIME', result = {coinTest3.ToString()}.");

            Coin coinTest4 = new Coin("Quarter");
            WriteLine($"coinTest4 expects 25, result = {coinTest4.ValueOf}.");

            Coin coinTest5 = new Coin(25);
            WriteLine($"coinTest5 expects 25, result = {coinTest5.ValueOf}.");

            Coin coinTest6 = new Coin(15);
            WriteLine($"coinTest6 expects 0, result = {coinTest6.ValueOf}.");
        }

        private Denomination AbbrevNameToFullName(string firstLetter) {
            switch (firstLetter.ToUpper()) {
                case "N":
                    return Denomination.NICKEL;
                case "D":
                    return Denomination.DIME;
                case "Q":
                    return Denomination.QUARTER;
                case "H":
                    return Denomination.HALFDOLLAR;
                default:
                    return Denomination.SLUG;
            }
        }
    }
}
