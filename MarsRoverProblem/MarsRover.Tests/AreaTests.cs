using System;
using FluentAssertions;
using MarsRover.Domain;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AreaTests
    {
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        public void Location_Creation(int x, int y)
        {
            var area = new Area(x, y);

            area.Width.Should().Be(x);
            area.Height.Should().Be(y);
        }

        [TestCase(-1, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, -1, ExpectedException = typeof(ArgumentException))]
        public void NegativeOrZeroArea_CannotExists(int x, int y)
        {
            var area = new Area(x, y);
        }

        [TestCase(4, 5, 1, 1, true)]
        [TestCase(4, 5, 4, 5, true)]
        [TestCase(5, 4, 5, 4, true)]
        [TestCase(2, 2, 3, 2, false)]
        public void LocationIn(int areaWidth, int areaHeight, int x, int y, bool isInside)
        {
            var area = new Area(areaWidth, areaHeight);
            var location = new Location(x, y);

            area.IsInside(location).Should().Be(isInside);
        }
    }
}