
namespace SimpleVendingMachine {
    class Can {

        public Flavor Flavor { get; private set; } = Flavor.REGULAR;

        // Constructor(s)
        public Can() {
        }

        public Can(Flavor flavor) {
            Flavor = flavor;
        }
    }
}
