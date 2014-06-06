using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MapLink.API.Models;
using MapLink.Domain;
using MapLink.Services;

namespace MapLink.API.Controllers
{
    public class RouteController : ApiController
    {
        private readonly IRouteService _routeService;
        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public async Task<HttpResponseMessage> PostRoute(RouteViewModel routeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var route = await _routeService.CalculateRouteAsync(routeViewModel.AddressSearch, routeViewModel.RouteType);
                    return Request.CreateResponse(HttpStatusCode.OK, route);
                }
                catch (Exception ex)
                {
                    // TODO: Logar a exceção.
                    // ...
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro durante a requisição. Tente novamente.");
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState.ToString());
        }
    }
}
