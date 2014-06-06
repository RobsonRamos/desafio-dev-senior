using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MapLink.API.Controllers;
using MapLink.API.Models;
using MapLink.Common.IoC;
using MapLink.Domain;
using MapLink.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MapLink.API.Tests
{
    [TestFixture]
    
    public class RouteControllerTests
    {
        private HttpServer _server;
        private string _url = "http://localhost:2205/";

        [SetUp]
        public void SetUp()
        {
            var config = new HttpConfiguration();
            
            config.Routes.MapHttpRoute(name: "Default", routeTemplate: "api/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });
            config.DependencyResolver = new DependencyResolverBuilder().DependencyResolverWebAPI;
            
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
           
            _server = new HttpServer(config);
            
        }

        [TearDown]
        public void Dispose()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }

        private HttpRequestMessage CreateRequest(string url, string mthv, HttpMethod method)
        {
            var request = new HttpRequestMessage();

            request.RequestUri = new Uri(_url + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
            request.Method = method;

            return request;
        }

        private HttpRequestMessage CreateRequest<T>(string url, string mthv, HttpMethod method, T content, MediaTypeFormatter formatter) where T : class
        {
            HttpRequestMessage request = CreateRequest(url, mthv, method);
            request.Content = new ObjectContent<T>(content, formatter);

            return request;
        }

        [Test]
        [Ignore]
        public void Test_With_Sample_Json()
        {
            var client = new HttpClient(_server);

            IRouteService routeService =
                (IRouteService) new DependencyResolverBuilder().DependencyResolverWebAPI.GetService(typeof (IRouteService));

            var model = new RouteViewModel
            {
                AddressSearch = new List<AddressSearch>()
                {
                    new AddressSearch("Avenida Paulista", 1000, "São Paulo", "SP"),
                    new AddressSearch("Avenida Paulista", 2000, "São Paulo", "SP")

                },
                RouteType = RouteType.DefaultRouteFaster
            };

            var json = JsonConvert.SerializeObject(model);

            var request = CreateRequest("api/Route", "application/json", HttpMethod.Get, model, new JsonMediaTypeFormatter());
   
            
            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                Assert.NotNull(response.Content);
                
                Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);

                var result = JsonConvert.DeserializeObject<Route>(response.Content.ReadAsStringAsync().Result);

                Assert.IsTrue(result.TotalDistance > 0);
            }

            request.Dispose();
        }
    }
}
