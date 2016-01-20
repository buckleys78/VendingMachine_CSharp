using System;

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
            if (!Enum.TryParse(coinName.ToUpper(), out coinType)) {
                //Todo Throw Exception
            }
            Enumeral = coinType;
        }

        // Properties
        public Denomination Enumeral {get; set;}

        public decimal ValueOf {
            get {
                return (int)Enumeral;
            }
        }

        public override string ToString() {
            return Enumeral.ToString();
        }
    }
}
