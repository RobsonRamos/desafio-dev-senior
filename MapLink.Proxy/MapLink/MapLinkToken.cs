using System.Configuration;
using MapLink.Proxy.Contracts;

namespace MapLink.Proxy
{
    public class MapLinkToken : IToken
    {
        private static string _tokenValue;

        public MapLinkToken()
        {
            if (string.IsNullOrEmpty(_tokenValue))
            {
                _tokenValue = ConfigurationManager.AppSettings["MapLinkToken"];                
            }
        }

        public string Tokenvalue 
        {
            get { return _tokenValue; }
        }
    }
}
