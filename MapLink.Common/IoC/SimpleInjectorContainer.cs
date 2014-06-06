using MapLink.Proxy;
using MapLink.Proxy.Config;
using MapLink.Proxy.Contracts;
using MapLink.Services;
using SimpleInjector;

namespace MapLink.Common.IoC
{
    public class SimpleInjectorContainer : Container
    {
        public SimpleInjectorContainer()
        {
            
            RegisterDependencies();

            Verify();
        }

        public void RegisterDependencies()
        {
            // Services.
            Register<IRouteService,RouteService>();


            Register<ICoordinateFinder, MapLinkCoordinateFinder>();
            Register<IRouteCalculator, MapLinkRouteCalculator>();
            Register<IMapLinkConfig, MapLinkConfig>();
            Register<IToken, MapLinkToken>();
        }

    }
}
