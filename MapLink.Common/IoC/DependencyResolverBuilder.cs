using SimpleInjector.Integration.WebApi;

namespace MapLink.Common.IoC
{
    public class DependencyResolverBuilder
    {
        public System.Web.Http.Dependencies.IDependencyResolver DependencyResolverWebAPI 
        {
            get
            {
                return new SimpleInjectorWebApiDependencyResolver(new SimpleInjectorContainer());                 
            }
        }
    }
}
