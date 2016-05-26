using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;

namespace MarsRover.Domain
{
    public struct Location
    {
        private readonly int _x;
        private readonly int _y;


        public Location(int x, int y)
        {
            Ensure.That(x).IsGte(0);
            Ensure.That(y).IsGte(0);

            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }
    }
}
