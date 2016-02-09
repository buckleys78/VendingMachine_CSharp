using System;

namespace SimpleVendingMachine {
    public class Coin {
        public enum Denomination {
            SLUG = 0, NICKEL = 5, DIME = 10, QUARTER = 25, HALFDOLLAR = 50
        }

        // Constructor(s)
        public Coin() : this(Denomination.SLUG) { }

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

        public decimal ValueOf => (int)Enumeral / 100M;

        public override string ToString() => Enumeral.ToString();

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
