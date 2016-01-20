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
        public void AddACanOf(Flavor flavorName) {
            Debug.WriteLine($"CanRack.AddACanOf was called for flavor {flavorName.ToString()}.");
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.AddCan();
            }
        }

        private void ConfigureTheCanRack() {
            Bins = new Dictionary<Flavor, Bin>();
            Bins.Add(Flavor.REGULAR, new Bin(Flavor.REGULAR));
            Bins.Add(Flavor.ORANGE, new Bin(Flavor.ORANGE));
            Bins.Add(Flavor.LEMON, new Bin(Flavor.LEMON));
            Debug.Write(Inventory());
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

        public void RemoveACanOf(Flavor flavorName) {
            Debug.WriteLine($"CanRack.RemoveACanOf was called for flavor {flavorName}.");
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.RemoveCan();
            }
        }

        public string Inventory() {
            string inventory = "";

            foreach (var key in Bins.Keys) {
                inventory += (Bins[key].Inventory + "\n");
            }
            return inventory;
        }
    }
}
