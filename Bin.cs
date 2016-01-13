using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVendingMachine {
    class Bin {
        private int maxCapacity = 3;

        public Bin(string flavor) {
            Flavor = flavor;
        }

        public bool IsEmpty {
            get {
                return Quantity == 0;
            }
        }

        public bool IsFull {
            get {
                return Quantity == maxCapacity;
            }
        }

        public string Flavor { get; set; }
        public int Quantity { get; set; }

        // methods
        public void AddCan() {
            if (!IsFull) {
                Quantity++;
            }
        }

        public void EmptyBin() {
            Quantity = 0;
        }

        public void FillBin() {
            Quantity = maxCapacity;
        }

        public void RemoveCan() {
            if (!IsEmpty) {
                Quantity--;
            }
        }
    }
}
