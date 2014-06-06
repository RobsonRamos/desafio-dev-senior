using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public class ZipCode
    {
        private readonly string _code;

        public ZipCode(string code)
        {
            _code = code;
        }

        public string Code
        {
            get { return _code; }
        }

        public static implicit operator ZipCode(string code)
        {
            return new ZipCode(code);
        }

        public override string ToString()
        {
            return string.Format("Zip Code : {0}", _code);
        }

    }
}
