
namespace SimpleVendingMachine {
    class Can {

        public Flavor Flavor { get; private set; }

        // Constructor(s)
        public Can() {
            Flavor = Flavor.REGULAR;
        }

        public Can(Flavor flavor) {
            Flavor = flavor;
        }
    }
}
