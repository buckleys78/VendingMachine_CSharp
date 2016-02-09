using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleVendingMachine {
    public class CoinBox : INotifyPropertyChanged {
        private Dictionary<Coin.Denomination, int> box;

        public event PropertyChangedEventHandler PropertyChanged;

        // Constructor(s)
        public CoinBox() : this(new List<Coin.Denomination>()) { }

        public CoinBox(List<Coin.Denomination> SeedMoney) {
            box = new Dictionary<Coin.Denomination, int>();
            foreach (Coin.Denomination coinType in Enum.GetValues(typeof(Coin.Denomination))) {
                box.Add(coinType, 0);
            }
            SeedMoney.ForEach((coin) => Deposit(coin));
        }

        // Properties
        public List<KeyValuePair<Coin.Denomination, int>> ListOfContents {
            get {
                List<KeyValuePair<Coin.Denomination, int>> coinList = box.ToList();
                return coinList;
            }
        }

        public int HalfDollarCount => CoinCount(Coin.Denomination.HALFDOLLAR);

        public int QuarterCount => CoinCount(Coin.Denomination.QUARTER);

        public int DimeCount => CoinCount(Coin.Denomination.DIME);

        public int NickelCount => CoinCount(Coin.Denomination.NICKEL);

        public int SlugCount => CoinCount(Coin.Denomination.SLUG);

        public decimal ValueOf {
            get {
                var result = from coinType in box
                             select coinType.Value * (int)coinType.Key;
                return result.Sum() / 100M;
            }
        }

        // Methods
        public bool HasChangeFor(decimal change) {
            // crude changer, may later require a real 'make change' algorithm (likely recursive)
            //  current need is no more than $0.15 under any scenario
            decimal maxAmountToChange = 0.25M;
            int amt = (int) (Math.Min(change, maxAmountToChange) * 100M);
            int nickelCount = NickelCount;
            int dimeCount = DimeCount;
            int quarterCount = QuarterCount;

            if ((amt * 100M) % 5 != 0) return false;
            if (amt <=  0) return true;
            if (amt ==  5 && nickelCount > 0) return true;
            if (amt == 10 && (nickelCount >= 2 || dimeCount >= 1)) return true;
            if (amt == 15 && ((dimeCount >= 1 && nickelCount >= 1)
                                || nickelCount >= 3)) return true;
            if (amt == 20 && ((dimeCount >=1 && nickelCount>=2)
                                || dimeCount >= 2 || nickelCount >= 4)) return true;
            if (amt == 25 && (quarterCount >= 1 || nickelCount >= 5
                                || (dimeCount >= 2 && nickelCount >= 1)
                                || (dimeCount >= 1 && nickelCount >= 3))) return true;
            return false;
        }

        public void ReturnChangeFor(decimal amt) {
            if (amt == 0.05M && HasChangeFor(.05M)) Withdraw(Coin.Denomination.NICKEL);
            if (amt == 0.10M && HasChangeFor(.10M)) {
                if (DimeCount >= 1) {
                    Withdraw(Coin.Denomination.DIME);
                } else {
                    Withdraw(Coin.Denomination.NICKEL);
                    Withdraw(Coin.Denomination.NICKEL);
                }
            }
            if (amt == 0.15M && HasChangeFor(.15M)) {
                if (DimeCount >= 1) {
                    Withdraw(Coin.Denomination.DIME);
                    Withdraw(Coin.Denomination.NICKEL);
                } else {
                    for (int i = 1; i <= 3; i++) Withdraw(Coin.Denomination.NICKEL);
                }
            }
        }

        private int CoinCount(Coin.Denomination kindOfCoin) {
            var result = from coinType in box
                         where coinType.Key == kindOfCoin
                         select coinType.Value;
            return result.Sum();
        }

        public void Deposit(Coin.Denomination coinType) {
            box[coinType]++;
            NotifyPropertyChanged();
        }

        public void EmptyAllCoins() {
            foreach (Coin.Denomination coinType in box.Keys) {
                box[coinType] = 0;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void TransferToThisBox(CoinBox incomingCoins) {
            List<KeyValuePair<Coin.Denomination, int>> listOfIncomingCoins = incomingCoins.ListOfContents;
            foreach (KeyValuePair<Coin.Denomination, int> coinType in listOfIncomingCoins) {
                for (int i = coinType.Value; i > 0; i--) {
                    if (incomingCoins.Withdraw(coinType.Key)) Deposit(coinType.Key);
                }
            }
        }

        public bool Withdraw(Coin.Denomination coinType) {
            if (CoinCount(coinType) > 0) {
                box[coinType]--;
                NotifyPropertyChanged();
                return true;
            } else {
                return false;
            }
        }
            
        public override string ToString() {
            return $"{HalfDollarCount} HalfDollar{Pluralizer(HalfDollarCount)} \n" + 
                   $"{QuarterCount} Quarter{Pluralizer(QuarterCount)} \n" +
                   $"{DimeCount} Dime{Pluralizer(DimeCount)} \n" +
                   $"{NickelCount} Nickel{Pluralizer(NickelCount)} \n" +
                   $"{SlugCount} Slug{Pluralizer(SlugCount)} \n";
        }

        private string Pluralizer(int qty) => qty == 1? string.Empty : "s";

    }
}
