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
        Dictionary<string, Bin> Bins { get; set; }

        // methods
        public void AddACanOf(string flavorName) {
            Debug.WriteLine($"CanRack.AddACanOf was called for flavor {flavorName}.");
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.AddCan();
            }
        }

        private void ConfigureTheCanRack() {
            Bins = new Dictionary<string, Bin>();
            Bins.Add("Regular", new Bin("Regular"));
            Bins.Add("Orange", new Bin("Orange"));
            Bins.Add("Lemon", new Bin("Lemon"));
            Debug.Write(Inventory());
        }

        public void EmptyTheCanRackOf(string flavorName) {
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

        public bool IsEmpty(string flavorName) {
            Debug.WriteLine($"CanRack.IsEmpty was called for flavor {flavorName}.");
            Bin bin;
            bool isEmpty = true;
            if (Bins.TryGetValue(flavorName, out bin)) {
                isEmpty = bin.IsEmpty;
            }
            return isEmpty;
        }

        public bool IsFull(string flavorName) {
            Debug.WriteLine($"CanRack.IsFull was called for flavor {flavorName}.");
            Bin bin;
            bool isFull = false;
            if (Bins.TryGetValue(flavorName, out bin)) {
                isFull = bin.IsFull;
            }
            return isFull;
        }

        public void RemoveACanOf(string flavorName) {
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
