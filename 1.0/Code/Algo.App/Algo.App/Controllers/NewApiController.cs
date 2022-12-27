using Algo.App.Dtos;
using Algo.App.Models;
using Algo.App.Services.DijkstraService;
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
        private readonly IDijkstraService _dijkstraService;
        /*
         private readonly ITravellingSalesmanService _travellingSalesmanService;
         private readonly IGeneticService _geneticService;
        private readonly IFloydService _floydService;
         */

        public NewApiController(IDijkstraService dijkstraService

            /* 
               , ITravellingSalesmanService travellingSalesmanService
               , IGeneticService geneticService
               ,  IFloydService floydService
             */

            )
        {
            _dijkstraService = dijkstraService;

            /* _travellingSalesmanService = travellingSalesmanService;
                _geneticService = geneticService;
                _floydService = floydService;
             */

        }

        [HttpGet("dijkstra")]
        public ActionResult<ServiceResponse> Get(GetRouteDto route)
        {
            return Ok(_dijkstraService.GetShortestPath(route));
        }

        /* [HttpGet("traveling_Salesman")]
         public ActionResult<ServiceResponse> Get(GetRouteDto route)
         {
             return Ok(_travellingSalesmanService.GetShortestPath(route));
         }

         [HttpGet("genetic")]
         public ActionResult<ServiceResponse> Get(GetRouteDto route)
         {
             return Ok(_geneticService.GetShortestPath(route));
         }

         [HttpGet("floydWarshall")]
         public ActionResult<ServiceResponse> Get(GetRouteDto route)
         {
             return Ok(_floydService.GetShortestPath(route));
         }

         */

    }
}
