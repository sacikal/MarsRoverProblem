using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Domain
{
    public class Rover
    {
        private readonly Area _area;
        private Location _location;
        private IHeading _heading;

        public Rover(Area area, Location location, IHeading heading)
        {
            _area = area;
            _location = location;
            _heading = heading;
        }

        public Location Location
        {
            get { return _location; }
        }

        public Area Area
        {
            get { return _area; }
        }

        public IHeading Heading
        {
            get { return _heading; }
        }

        public static Rover Create(string firstLine, string secondLine)
        {
            //iyileştir
            var headingTypes = new List<IHeading>()
            { 
                new NorthHeading(), new EastHeading(), new WestHeading(), new SouthHeading()
            };

            var area = new Area(Convert.ToInt32(firstLine[0].ToString()), Convert.ToInt32(firstLine[1].ToString()));
            var location = new Location(Convert.ToInt32(secondLine[0].ToString()), Convert.ToInt32(secondLine[1].ToString()));
            var heading = headingTypes.FirstOrDefault(s => s.Code == secondLine[2].ToString());

            return new Rover(area, location, heading);
        }

        public void Process(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid command: {0}", command));
                }
            }
        }

        public void Move()
        {
            var location = _heading.Move(_location);
            if (!_area.IsInside(location))
                throw new OutOfAreaException();

            _location = location;
        }

        public void TurnRight()
        {
            _heading = _heading.TurnRight();
        }

        public void TurnLeft()
        {
            _heading = _heading.TurnLeft();
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}", _location.X, _location.Y, _heading.Code);
        }
    }
}