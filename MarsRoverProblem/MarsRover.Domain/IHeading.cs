namespace MarsRover.Domain
{
    public interface IHeading
    {
        string Code { get; }
        Location Move(Location location);
        IHeading TurnRight();
        IHeading TurnLeft();
    }
}