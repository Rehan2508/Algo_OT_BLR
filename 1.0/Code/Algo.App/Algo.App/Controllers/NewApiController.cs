using Algo.App.Data;
using Algo.App.Dtos;
using Algo.App.Models;
using Algo.App.Services.DijkstraService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewApiController : Controller
    {

        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDijkstraService _dijkstraService;
        private readonly IDijkstraService _floydService;
        private readonly IDijkstraService _geneticService;

        public NewApiController(IDijkstraService dijkstraService, IDijkstraService floydService, IDijkstraService geneticService,
            IHttpContextAccessor httpContextAccessor,
            DataContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _dijkstraService = dijkstraService;
            _floydService = floydService;
            _geneticService = geneticService;

            List<Routes> routeList = _context.Routes.ToList();
            _httpContextAccessor.HttpContext.Session.SetComplexData("RoutesTable", routeList);
            List<CityCode> cityList = _context.CityCodes.ToList();
            _httpContextAccessor.HttpContext.Session.SetComplexData("CityTable", cityList);
            if (DataParsing.cityCodes.Count == 0)
            {
                DataParsing.setCityCodes(cityList);
                DataParsing.setCityName(cityList);
            }
        }
        [HttpPost("dijkstra")]
        public ActionResult<ServiceResponse> DijkstraApi(GetRouteDto route)
        {
            return Ok(_dijkstraService.GetShortestPath(route));
        }

        [HttpPost("floyd")]
        public ActionResult<ServiceResponse> FloydApi(GetRouteDto route)
        {
            return Ok(_floydService.GetShortestPath(route));
        }

        [HttpPost("genetic")]
        public ActionResult<ServiceResponse> GeneticApi(GetRouteDto route)
        {
            return Ok(_geneticService.GetShortestPath(route));
        }
    }
}
