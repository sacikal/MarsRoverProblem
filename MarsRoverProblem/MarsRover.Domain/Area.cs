using System;
using EnsureThat;

namespace MarsRover.Domain
{
    public class Area
    {
        private readonly int _width;
        private readonly int _height;


        public Area(int width, int height)
        {
            Ensure.That(width).IsGte(0);
            Ensure.That(height).IsGte(0);

            _width = width;
            _height = height;
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public bool IsInside(Location location)
        {
            return location.X <= _width && location.Y <= _height;
        }
    }
}