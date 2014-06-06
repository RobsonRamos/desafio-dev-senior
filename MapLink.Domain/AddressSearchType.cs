using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public enum AddressSearchType : short
    {
		ExactSearch = 0,
		SearchStartingWithTheTypedText = 1,
		SearchTheTextAnywhereTypedAddress = 2,
		SearchAddressesWhichEndWithTheEnteredText = 3
    }
}
