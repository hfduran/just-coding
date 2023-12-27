public class Bicycle
{
    // Bicycle's Fields/Variables
    public int Cadence // Public: Can be accessed from anywhere
    {
        get // get - define a method to retrieve the property
        {
            return _cadence;
        }
        set // set - define a method to set a property
        {
            _cadence = value; // Value is the value passed in to the setter
        }
    }
    private int _cadence;

    protected virtual int Gear // Protected: Accessible from the class and subclasses
    // Virtual: Can be overriden by subclasses
    {
        get; // creates an auto property so you don't need a member field
        set;
    }

    internal int Wheels // Internal: Accessible from within the assembly
    {
        get;
        private set; // You can set modifiers on the get/set methods
    }

    int _speed; // Everything is private by default: Only accessible from within this class.
                // can also use keyword private
    public string Name { get; set; }

    // Properties also have a special syntax for when you want a readonly property
    // that simply returns the result of an expression
    public string LongName => Name + " " + _speed + " speed";

    // Enum is a value type that consists of a set of named constants
    // It is really just mapping a name to a value (an int, unless specified otherwise).
    // The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
    // An enum can't contain the same value twice.
    public enum BikeBrand
    {
        AIST,
        BMC,
        Electra = 42, //you can explicitly set a value to a name
        Gitane // 43
    }
    // We defined this type inside a Bicycle class, so it is a nested type
    // Code outside of this class should reference this type as Bicycle.BikeBrand

    public BikeBrand Brand; // After declaring an enum type, we can declare the field of this type

    // Decorate an enum with the FlagsAttribute to indicate that multiple values can be switched on
    // Any class derived from Attribute can be used to decorate types, methods, parameters etc
    // Bitwise operators & and | can be used to perform and/or operations

    [Flags]
    public enum BikeAccessories
    {
        None = 0,
        Bell = 1,
        MudGuards = 2, // need to set the values manually!
        Racks = 4,
        Lights = 8,
        FullPackage = Bell | MudGuards | Racks | Lights
    }

    // Usage: aBike.Accessories.HasFlag(Bicycle.BikeAccessories.Bell)
    // Before .NET 4: (aBike.Accessories & Bicycle.BikeAccessories.Bell) == Bicycle.BikeAccessories.Bell
    public BikeAccessories Accessories { get; set; }

    // Static members belong to the type itself rather than specific object.
    // You can access them without a reference to any object:
    // Console.WriteLine("Bicycles created: " + Bicycle.bicyclesCreated);
    public static int BicyclesCreated { get; set; }

    // readonly values are set at run time
    // they can only be assigned upon declaration or in a constructor
    readonly bool _hasCardsInSpokes = false; // read-only private

    // Constructors are a way of creating classes
    // This is a default constructor
    public Bicycle()
    {
        this.Gear = 1; // you can access members of the object with the keyword this
        Cadence = 50;  // but you don't always need it
        _speed = 5;
        Name = "Bontrager";
        Brand = BikeBrand.AIST;
        BicyclesCreated++;
    }

    // This is a specified constructor (it contains arguments)
    public Bicycle(int startCadence, int startSpeed, int startGear,
                   string name, bool hasCardsInSpokes, BikeBrand brand)
        : base() // calls base first
    {
        Gear = startGear;
        Cadence = startCadence;
        _speed = startSpeed;
        Name = name;
        _hasCardsInSpokes = hasCardsInSpokes;
        Brand = brand;
    }

    // Constructors can be chained
    public Bicycle(int startCadence, int startSpeed, BikeBrand brand) :
        this(startCadence, startSpeed, 0, "big wheels", true, brand)
    {
    }

    // Function Syntax:
    // <public/private/protected> <return type> <function name>(<args>)

    // classes can implement getters and setters for their fields
    // or they can implement properties (this is the preferred way in C#)

    // Method parameters can have default values.
    // In this case, methods can be called with these parameters omitted
    public void SpeedUp(int increment = 1)
    {
        _speed += increment;
    }

    public void SlowDown(int decrement = 1)
    {
        _speed -= decrement;
    }

    // properties get/set values
    // when only data needs to be accessed, consider using properties.
    // properties may have either get or set, or both
    private bool _hasTassles; // private variable
    public bool HasTassles // public accessor
    {
        get { return _hasTassles; }
        set { _hasTassles = value; }
    }

    // You can also define an automatic property in one line
    // this syntax will create a backing field automatically.
    // You can set an access modifier on either the getter or the setter (or both)
    // to restrict its access:
    public bool IsBroken { get; private set; }

    // Properties can be auto-implemented
    public int FrameSize
    {
        get;
        // you are able to specify access modifiers for either get or set
        // this means only Bicycle class can call set on Framesize
        private set;
    }

    // It's also possible to define custom Indexers on objects.
    // All though this is not entirely useful in this example, you
    // could do bicycle[0] which returns "chris" to get the first passenger or
    // bicycle[1] = "lisa" to set the passenger. (of this apparent quattrocycle)
    private string[] passengers = { "chris", "phil", "darren", "regina" };

    public string this[int i]
    {
        get
        {
            return passengers[i];
        }

        set
        {
            passengers[i] = value;
        }
    }

    // Method to display the attribute values of this Object.
    public virtual string Info()
    {
        return "Gear: " + Gear +
                " Cadence: " + Cadence +
                " Speed: " + _speed +
                " Name: " + Name +
                " Cards in Spokes: " + (_hasCardsInSpokes ? "yes" : "no") +
                "\n------------------------------\n"
                ;
    }

    public override string ToString()
    {
        return this.Info();
    }

    // Methods can also be static. It can be useful for helper methods
    public static bool DidWeCreateEnoughBicycles()
    {
        // Within a static method, we only can reference static class members
        return BicyclesCreated > 9000;
    } // If your class only needs static members, consider marking the class itself as static.


} // end class Bicycle