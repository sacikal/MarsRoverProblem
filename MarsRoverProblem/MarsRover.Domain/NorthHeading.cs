namespace MarsRover.Domain
{
    public class NorthHeading : IHeading
    {
        public string Code { get { return "N"; } }

        public Location Move(Location location)
        {
            return new Location(location.X, location.Y + 1);
        }

        public IHeading TurnRight()
        {
            return new EastHeading();
        }

        public IHeading TurnLeft()
        {
            return new WestHeading();
        }
    }
}