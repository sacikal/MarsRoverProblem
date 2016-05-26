using System;
using FluentAssertions;
using MarsRover.Domain;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Rover_CanBePutOnALocation()
        {
            var location = new Location(1, 1);
            var area = new Area(4, 4);

            IHeading heading = new NorthHeading(); //nereye bakıyor?
            var rover = new Rover(area, location, heading);

            rover.Location.Should().NotBeNull();
            rover.Location.Should().Be(location);

            rover.Area.Should().NotBeNull();
            rover.Area.Should().Be(area);

            rover.Heading.Should().NotBeNull();
            rover.Heading.Should().Be(heading);
        }

        [TestCase("55", "12N", 5, 5, "12N")]
        [TestCase("55", "33E", 5, 5, "33E")]
        [TestCase("55", "00W", 5, 5, "00W")]
        [TestCase("55", "00S", 5, 5, "00S")]
        public void RoverCreationFromSyntax(string firstLine, string secondLine, int areaWidth, int areaHeight, string result)
        {
            Rover rover = Rover.Create(firstLine, secondLine);

            rover.Area.Width.Should().Be(areaWidth);
            rover.Area.Height.Should().Be(areaHeight);

            rover.ToString().Should().Be(result);
        }

        [TestCase("55", "12N", "LMLMLMLMM", "13N")]
        [TestCase("55", "33E", "MMRMMRMRRM", "51E")]
        [TestCase("33", "33E", "M", "", ExpectedException = typeof(OutOfAreaException))]
        public void RoverMovement(string firstLine, string secondLine, string thirdLine, string result)
        {
            Rover rover = Rover.Create(firstLine, secondLine);
            rover.Process(thirdLine);

            rover.ToString().Should().Be(result);
        }
    }
}
