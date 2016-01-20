using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVendingMachine {
    class PurchasePrice {
        public PurchasePrice() {
            PriceInDollars = 0;
        }

        public PurchasePrice(int initialPriceInCents) {
            PriceInDollars = initialPriceInCents / 100.0M;
        }

        public int Price {
            get {
                return (int) (PriceInDollars * 100);
            }
        }

        public decimal PriceInDollars { get; private set; }

    }
}
