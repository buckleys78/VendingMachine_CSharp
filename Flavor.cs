using System;
using System.Collections.Generic;

public enum Flavor {
    REGULAR,
    ORANGE,
    LEMON
}

public static class FlavorOps {
    //private static List<Flavor> _allFlavors = new List<Flavor>();

    // Constructor(s)
    static FlavorOps() {
        AllFlavors = new List<Flavor>();
        foreach (Flavor flavor in Enum.GetValues(typeof(Flavor))) {
            AllFlavors.Add(flavor);
        }
    }

    // Properties
    public static Flavor ToFlavor(string flavorName) {
        Flavor flavor = Flavor.REGULAR;
        try {
            flavor = (Flavor)Enum.Parse(typeof(Flavor), flavorName.ToUpper());
        } catch (Exception ex) {
            throw new VENDBADFLAVORException($"{flavorName} is not a valid flavor.", ex);
        }
        return flavor;
    }

    public static List<Flavor> AllFlavors { get; }

    // Methods
    public static bool HasFlavor(string flavorName) {
        return Enum.IsDefined(typeof(Flavor), flavorName.ToUpper());
    }
}

public class VENDBADFLAVORException : Exception {
    public VENDBADFLAVORException() : base("Invalid flavor choice") { }

    public VENDBADFLAVORException(string messageValue) : base(messageValue) { }

    public VENDBADFLAVORException(string messageValue, Exception inner) : base(messageValue, inner) { }
}
