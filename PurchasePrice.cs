using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVendingMachine {
    class PurchasePrice {
        public PurchasePrice() {
            Price = 0;
        }

        public PurchasePrice(int initialPrice) {
            Price = initialPrice;
        }

        public int Price { get; set; }

    }
}
