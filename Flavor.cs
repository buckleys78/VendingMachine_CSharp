using System;
using System.Collections.Generic;

public enum Flavor {
    REGULAR,
    ORANGE,
    LEMON
}

public static class FlavorOps {
    // Properties
    public static List<Flavor> AllFlavors { get; } = new List<Flavor>();

    // Constructor(s)
    static FlavorOps() {
        foreach (Flavor flavor in Enum.GetValues(typeof(Flavor))) {
            AllFlavors.Add(flavor);
        }
    }

    // Methods
    public static bool HasFlavor(string flavorName) {
        return Enum.IsDefined(typeof(Flavor), flavorName.ToUpper());
    }

    public static Flavor ToFlavor(string flavorName) {
        Flavor flavor;
        if (HasFlavor(flavorName)) {
            flavor = (Flavor)Enum.Parse(typeof(Flavor), flavorName.ToUpper());
        } else {
            throw new VendBadFlavorException($"{flavorName} is not a valid flavor.");
        }
        return flavor;
    }
}

public class VendBadFlavorException : Exception {
    public VendBadFlavorException() : base("Invalid flavor choice") { }

    public VendBadFlavorException(string messageValue) : base(messageValue) { }

    public VendBadFlavorException(string messageValue, Exception inner) : base(messageValue, inner) { }
}
