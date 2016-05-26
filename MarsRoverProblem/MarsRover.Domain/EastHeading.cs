namespace MarsRover.Domain
{
    public class EastHeading : IHeading
    {
        public string Code { get { return "E"; } }

        public Location Move(Location location)
        {
            return new Location(location.X + 1, location.Y);
        }

        public IHeading TurnRight()
        {
            return new SouthHeading();
        }

        public IHeading TurnLeft()
        {
            return new NorthHeading();
        }
    }
}