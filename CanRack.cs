using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimpleVendingMachine {
    class CanRack {
        // constructor(s)
        public CanRack() {
            ConfigureTheCanRack();
            FillTheCanRack();
        }

        // properties
        Dictionary<Flavor, Bin> Bins { get; set; }

        // methods
        public void AddACanOf(string flavorName) {
            AddACanOf((Flavor)Enum.Parse(typeof(Flavor), flavorName));
        }

        public void AddACanOf(Flavor flavorName) {
            Debug.WriteLine($"CanRack.AddACanOf was called for flavor {flavorName.ToString()}.");
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.AddCan();
            } else {
                Debug.WriteLine($"unknown flavor {flavorName}");
            }
        }

        private void ConfigureTheCanRack() {
            // new C#6 option
            Bins = new Dictionary<Flavor, Bin> {
                [Flavor.REGULAR] = new Bin(Flavor.REGULAR),
                [Flavor.ORANGE] = new Bin(Flavor.ORANGE),
                [Flavor.LEMON] = new Bin(Flavor.LEMON)
            };
            Debug.Write(DisplayCanRack());
        }

        public void EmptyTheCanRackOf(Flavor flavorName) {
            Debug.WriteLine($"CanRack.EmptyTheCanRackOf was called for flavor {flavorName}.");
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.EmptyBin();
            }
        }

        public void FillTheCanRack() {
            Debug.WriteLine($"CanRack.FillTheCanRack was called.");
            foreach (var flavorName in Bins.Keys) {
                Bins[flavorName].FillBin();
            }
        }

        public bool IsEmpty() {
            return TotalInventory() == 0;
        }

        public bool IsEmpty(Flavor flavorName) {
            Debug.WriteLine($"CanRack.IsEmpty was called for flavor {flavorName}.");
            Bin bin;
            bool isEmpty = true;
            if (Bins.TryGetValue(flavorName, out bin)) {
                isEmpty = bin.IsEmpty;
            }
            return isEmpty;
        }

        public bool IsFull(Flavor flavorName) {
            Debug.WriteLine($"CanRack.IsFull was called for flavor {flavorName}.");
            Bin bin;
            bool isFull = false;
            if (Bins.TryGetValue(flavorName, out bin)) {
                isFull = bin.IsFull;
            }
            return isFull;
        }

        public void RemoveACanOf(string flavorName) {
            RemoveACanOf((Flavor)Enum.Parse(typeof(Flavor), flavorName));
        }

        public void RemoveACanOf(Flavor flavorName) {
            Debug.WriteLine($"CanRack.RemoveACanOf was called for flavor {flavorName}.");
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.RemoveCan();
            }
        }

        public bool StocksThisFlavor(string requestedFlavorName, ref Flavor selectedFlavor) {
            Flavor flavor = Flavor.REGULAR;
            bool stocksThisFlavor = Enum.TryParse(requestedFlavorName.ToUpper(), out flavor);
            selectedFlavor = flavor;
            return stocksThisFlavor;
        }

        private int TotalInventory() {
            int canCount = 0;
            foreach (var key in Bins.Keys) {
                canCount += (Bins[key].Quantity);
            }
            return canCount;
        }


        public string DisplayCanRack() {
            string inventory = "Inventory:\n";
            foreach (var key in Bins.Keys) {
                inventory += (Bins[key].Inventory + "\n");
            }
            return inventory += "\n";
        }

        public string ConsoleSelectionPrompt() {
            string prompt = "Select from the following: ";
            foreach (var key in Bins.Keys) {
                prompt += key.ToString() + ", ";
            }
            return prompt;
        }
    }
}
