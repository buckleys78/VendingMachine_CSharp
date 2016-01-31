using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVendingMachine {
    public class PurchasePrice {
        public PurchasePrice() {
            PriceInDollars = 0;
        }

        [Obsolete("Use the decimal version of the constructor instead",error:false)]
        public PurchasePrice(int initialPriceInCents) {
            PriceInDollars = initialPriceInCents / 100.0M;
        }

        public PurchasePrice(decimal initialPriceInDollars) {
            PriceInDollars = initialPriceInDollars;
        }

        public int Price {
            get {
                return (int) (PriceInDollars * 100);
            }
        }

        public decimal PriceInDollars { get; private set; }

    }
}
