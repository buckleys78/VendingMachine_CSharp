using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleVendingMachine {
    class CoinBox {
        private Dictionary<Coin.Denomination, int> box;

        // constructor to create an empty coin box 
        public CoinBox() : this(new List<Coin>()) {}

        public CoinBox(List<Coin> SeedMoney) {
            box = new Dictionary<Coin.Denomination, int>();
            foreach (Coin.Denomination coinType in Enum.GetValues(typeof(Coin.Denomination))) {
                box.Add(coinType, 0);
            }
            SeedMoney.ForEach((coin) => Deposit(coin.Enumeral));
        }

            
        // put a coin in the coin box 
        public void Deposit(Coin.Denomination coinType) {
            box[coinType]++;
        }

        // take a coin of the specified denomination out of the box 
        public Boolean Withdraw(Coin.Denomination coinType) {
            if (CoinCount(coinType) > 0) {
                box[coinType]--;
                return true;
            } else {
                return false;
            }
        }
            
        // number of half dollars in the coin box 
        public int HalfDollarCount {
            get { return CoinCount(Coin.Denomination.HALFDOLLAR); }
        }

        // number of quarters in the coin box 
        public int QuarterCount {
            get {
                return CoinCount(Coin.Denomination.QUARTER);
            }
        }

        // number of dimes in the coin box 
        public int DimeCount {
            get {
                return CoinCount(Coin.Denomination.DIME);
            }
        }

        // number of nickels in the coin box 
        public int NickelCount {
            get {
                return CoinCount(Coin.Denomination.NICKEL);
            }
        }

        // number of worthless coins in the coin box 
        public int SlugCount {
            get {
                return CoinCount(Coin.Denomination.SLUG);
            }
        }

        public override string ToString() {
            return $"{HalfDollarCount} HalfDollar{Pluralizer(HalfDollarCount)} \n" + 
                   $"{QuarterCount} Quarter{Pluralizer(QuarterCount)} \n" +
                   $"{DimeCount} Dime{Pluralizer(DimeCount)} \n" +
                   $"{NickelCount} Nickel{Pluralizer(NickelCount)} \n" +
                   $"{SlugCount} Slug{Pluralizer(SlugCount)} \n";
        }

        // total amount of money in the coin box 
        public decimal ValueOf {
            get {
                var result = from coinType in box
                             select coinType.Value * (int)coinType.Key;
                return result.Sum() / 100M;
            }
        }

        private int CoinCount(Coin.Denomination kindOfCoin) {
            var result = from coinType in box
                         where coinType.Key == kindOfCoin
                         select coinType.Value;
            return result.Sum();
        }

        private string Pluralizer(int qty) {
            return qty == 1 ? string.Empty : "s";
        }
    }
}
