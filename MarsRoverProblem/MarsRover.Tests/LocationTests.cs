using System;
using FluentAssertions;
using MarsRover.Domain;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class LocationTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        public void Location_Creation(int  x, int y)
        {
            var location = new Location(x, y);

            location.X.Should().Be(x);
            location.Y.Should().Be(y);
        }

        [TestCase(-1, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(1, -1, ExpectedException = typeof(ArgumentException))]
        public void NegativeLocation_CannotExists(int x, int y)
        {
            var location = new Location(x, y);
        }
    }
}