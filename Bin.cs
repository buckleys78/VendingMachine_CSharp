﻿using System.Diagnostics;
using System;

namespace SimpleVendingMachine {
    public class Bin {
        private const int maxCapacity = 3;
        private const int minCapacity = 0;

        //Constructor(s)
        public Bin(string flavor) {
            Flavor flavorAsType = Flavor.REGULAR;
            if (FlavorOps.HasFlavor(flavor)) {
                FlavorOps.ToFlavor(flavor);
            }
            Flavor = flavorAsType;
        }

        public Bin(Flavor flavor) {
            Flavor = flavor;
        }

        // Properties
        public Flavor Flavor { get; set; }

        public string Inventory {
            get {
                return $"{Quantity} cans of {Flavor.ToString()}";
            }
        }

        public bool IsEmpty {
            get {
                Debug.WriteLine($"Bin.IsEmpty was called for flavor {Flavor.ToString()}");
                return Quantity == minCapacity;
            }
        }

        public bool IsFull {
            get {
                Debug.WriteLine($"Bin.IsFull was called for flavor {Flavor.ToString()}");
                return Quantity == maxCapacity;
            }
        }

        public int Quantity { get; set; }

        // Methods
        public void AddCan() {
            if (!IsFull) {
                Quantity++;
            }
            Debug.WriteLine($"Bin.AddCan was called for flavor {Flavor.ToString()}, New Qty = {Quantity}.");
        }

        public void EmptyBin() {
            while (!IsEmpty) {
                RemoveCan();
            }
            Debug.WriteLine($"Bin.EmptyBin was called for flavor {Flavor.ToString()}, New Qty = {Quantity}.");
        }

        public void FillBin() {
            while (!IsFull) {
                AddCan();
            }
            Debug.WriteLine($"Bin.FillBin was called for flavor {Flavor.ToString()}, New Qty = {Quantity}.");
        }

        public void RemoveCan() {
            if (!IsEmpty) {
                Quantity--;
            }
            Debug.WriteLine($"Bin.RemoveCan was called for flavor {Flavor.ToString()}, New Qty = {Quantity}.");
        }
    }
}
