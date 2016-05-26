namespace MarsRover.Domain
{
    public class WestHeading : IHeading
    {
        public string Code { get { return "W"; } }

        public Location Move(Location location)
        {
            return new Location(location.X - 1, location.Y);
        }

        public IHeading TurnRight()
        {
            return new NorthHeading();
        }

        public IHeading TurnLeft()
        {
            return new SouthHeading();
        }
    }
}