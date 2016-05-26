namespace MarsRover.Domain
{
    public class SouthHeading : IHeading
    {
        public string Code { get { return "S"; } }

        public Location Move(Location location)
        {
            return new Location(location.X, location.Y - 1);
        }

        public IHeading TurnRight()
        {
            return new WestHeading();
        }

        public IHeading TurnLeft()
        {
            return new EastHeading();
        }
    }
}