using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVendingMachine {
    public class PurchasePrice {
        
        // Constructor(s)
        public PurchasePrice() : this(0M) { }

        [Obsolete("Use the decimal version of the constructor instead",error:false)]
        public PurchasePrice(int initialPriceInCents) {
            PriceInDollars = initialPriceInCents / 100.0M;
        }

        public PurchasePrice(decimal initialPriceInDollars) {
            PriceInDollars = initialPriceInDollars;
        }

        // Properties
        public decimal PriceInDollars { get; private set; }

        // Methods
        public decimal Change(decimal amount) => amount - PriceInDollars;

        public bool IsEnoughToPurchase(decimal amount) => Change(amount) >= 0;

        public int Price => (int)(PriceInDollars * 100);

        public decimal Shortage(decimal amount) => -Change(amount);

        //public List<KeyValuePair<Coin.Denomination, int>> CoinsNeededToMakeChange(decimal amt) {

        //};
    }
}
