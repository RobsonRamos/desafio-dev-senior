using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public class Route
    {

        public string TotalTime { get; set; }

        public decimal TotalDistance { get; set; }

        public decimal TotalFuelCost { get; set; }

        public decimal TotalCost { get; set; }        
    }
}
