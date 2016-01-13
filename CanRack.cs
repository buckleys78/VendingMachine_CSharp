using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.AddCan();
            }
        }

        private void ConfigureTheCanRack() {
            Dictionary<string, Bin> Bins = new Dictionary<string, Bin>();
            Bins.Add("Regular", new Bin("Regular"));
            Bins.Add("Orange", new Bin("Orange"));
            Bins.Add("Lemon", new Bin("Lemon"));
        }

        public void EmptyTheCanRackOf(string flavorName) {
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.EmptyBin();
            }
        }

        public void FillTheCanRack() {
            foreach (var flavorName in Bins.Keys) {
                Bins[flavorName].FillBin();
            }
        }

        public bool IsEmpty(string flavorName) {
            Bin bin;
            bool isEmpty = true;
            if (Bins.TryGetValue(flavorName, out bin)) {
                isEmpty = bin.IsEmpty;
            }
            return isEmpty;
        }

        public bool IsFull(string flavorName) {
            Bin bin;
            bool isFull = false;
            if (Bins.TryGetValue(flavorName, out bin)) {
                isFull = bin.IsFull;
            }
            return isFull;
        }

        public void RemoveACanOf(string flavorName) {
            Bin bin;
            if (Bins.TryGetValue(flavorName, out bin)) {
                bin.RemoveCan();
            }
        }

    }

}
