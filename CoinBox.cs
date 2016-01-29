using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleVendingMachine {
    class CoinBox {
        private List<Coin> box;

        // constructor to create an empty coin box 
        public CoinBox() : this(new List<Coin>()) { }

        // constructor to create a coin box with some coins in it 
        public CoinBox(List<Coin> SeedMoney) {
            box = new List<Coin>();
            SeedMoney.ForEach((coin) => box.Add(coin));
        }
            
        // put a coin in the coin box 
        public void Deposit(Coin coin) {
            box.Add(coin);
        }

        // take a coin of the specified denomination out of the box 
        public Boolean Withdraw(Coin.Denomination coin) {
            if (true) {
                return true;
            }
        }
            
        // number of half dollars in the coin box 
        public int HalfDollarCount {
            get {
                return CoinCount(Coin.Denomination.HALFDOLLAR);
            }
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
                var result = from coin in box
                             select coin.ValueOf;
                return result.Sum();
            }
        }

        private int CoinCount(Coin.Denomination kindOfCoin) {
            var result = from coin in box
                         where coin.Enumeral == kindOfCoin
                         select coin;
            return result.Count();
        }

        private string Pluralizer(int qty) {
            return qty == 1 ? string.Empty : "s";
        }
    }
}
