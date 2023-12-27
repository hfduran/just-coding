// PennyFarthing is a subclass of Bicycle
class PennyFarthing : Bicycle
{
    // (Penny Farthings are those bicycles with the big front wheel.
    // They have no gears.)

    // calling parent constructor
    public PennyFarthing(int startCadence, int startSpeed) :
        base(startCadence, startSpeed, 0, "PennyFarthing", true, BikeBrand.Electra)
    {
    }

    protected override int Gear
    {
        get
        {
            return 0;
        }
        set
        {
            throw new InvalidOperationException("You can't change gears on a PennyFarthing");
        }
    }

    public static PennyFarthing CreateWithGears(int gears)
    {
        var penny = new PennyFarthing(1, 1);
        penny.Gear = gears; // Oops, can't do this!
        return penny;
    }

    public override string Info()
    {
        string result = "PennyFarthing bicycle ";
        result += base.ToString(); // Calling the base version of the method
        return result;
    }
}