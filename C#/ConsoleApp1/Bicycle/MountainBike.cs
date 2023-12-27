// Classes can inherit only one other class, but can implement any amount of interfaces,
// however the base class name must be the first in the list and all interfaces follow
class MountainBike : Bicycle, IJumpable, IBreakable
{
    int damage = 0;

    public void Jump(int meters)
    {
        damage += meters;
    }

    public bool Broken
    {
        get
        {
            return damage > 100;
        }
    }
}