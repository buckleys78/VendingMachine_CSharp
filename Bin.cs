using System.Diagnostics;

namespace SimpleVendingMachine {
    class Bin {
        private int maxCapacity = 3;

        //Constructor(s)
        public Bin(string flavor) {
            Flavor = flavor;
        }

        // Properties
        public string Flavor { get; set; }

        public string Inventory {
            get {
                return $"{Quantity} cans of {Flavor}";
            }
        }

        public bool IsEmpty {
            get {
                Debug.WriteLine($"Bin.IsEmpty was called for flavor {Flavor}");
                return Quantity == 0;
            }
        }

        public bool IsFull {
            get {
                Debug.WriteLine($"Bin.IsFull was called for flavor {Flavor}");
                return Quantity == maxCapacity;
            }
        }

        public int Quantity { get; set; }

        // Methods
        public void AddCan() {
            if (!IsFull) {
                Quantity++;
            }
            Debug.WriteLine($"Bin.AddCan was called for flavor {Flavor}, New Qty = {Quantity}.");
        }

        public void EmptyBin() {
            Quantity = 0;
            Debug.WriteLine($"Bin.EmptyBin was called for flavor {Flavor}, New Qty = {Quantity}.");
        }

        public void FillBin() {
            Quantity = maxCapacity;
            Debug.WriteLine($"Bin.FillBin was called for flavor {Flavor}, New Qty = {Quantity}.");
        }

        public void RemoveCan() {
            if (!IsEmpty) {
                Quantity--;
            }
            Debug.WriteLine($"Bin.RemoveCan was called for flavor {Flavor}, New Qty = {Quantity}.");
        }
    }
}
