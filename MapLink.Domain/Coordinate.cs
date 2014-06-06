using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public struct Coordinate
    {
        private readonly double  _x;
        private readonly double _y;

        public Coordinate(double y, double x)
        {
            _y = y;
            _x = x;
        }

        public static Coordinate Empty()
        {
            return new Coordinate(0, 0);
        }

        public double Latitude
        {
            get { return _y; }
        }

        public double Longitude
        {
            get { return _x; }
        }
    }
}
