using System;

namespace MapLink.Domain
{
    public class District
    {
        private string _name;

        public District(string districtName)
        {

            if (string.IsNullOrWhiteSpace(districtName))
            {
                throw new ArgumentException("District Name is required.");
            }

            _name = districtName;
        }

        public string Name { get; set; }

        public static implicit operator District(string districtName)
        {
            return new District(districtName);
        }

        public override string ToString()
        {
            return string.Format("District Name : {0}", _name);
        }
    }
}