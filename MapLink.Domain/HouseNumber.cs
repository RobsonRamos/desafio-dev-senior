using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public struct HouseNumber
    {
        private int _number;

        public HouseNumber(int number)
        {
            if (number <= default(int))
            {
                throw new ArgumentException("Number must be greater than zero.");
            }

            _number = number;
        }

        public static implicit operator HouseNumber(int number)
        {
            return new HouseNumber(number);
        }

        public int Number
        {
            get { return _number; }
        }

        public override string ToString()
        {
            return string.Format("House Number : {0}", _number);
        }

    }
}
