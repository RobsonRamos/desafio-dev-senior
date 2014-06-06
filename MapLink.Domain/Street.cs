using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public class Street
    {
        private readonly string _name;

        
        public Street(string streetName)
        {
            _name = streetName;
        }

        public string Name
        {
            get { return _name; }
        }

        public static implicit operator Street(string streetName)
        {
            return new Street(streetName);
        }

        public override string ToString()
        {
            return string.Format("Street Name : {0}", _name);
        }
    }
}
