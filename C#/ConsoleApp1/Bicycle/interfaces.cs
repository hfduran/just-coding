// Interfaces only contain signatures of the members, without the implementation.
interface IJumpable
{
    void Jump(int meters); // all interface members are implicitly public
}

interface IBreakable
{
    bool Broken { get; } // interfaces can contain properties as well as methods & events
}