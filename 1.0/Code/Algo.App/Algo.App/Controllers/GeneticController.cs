using Algo.App.Data;
using Algo.App.Dtos;
using Algo.App.Services.GeneticService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Controllers
{
	public class GeneticController : Controller
	{
        private readonly IGeneticService _geneticService;

        public GeneticController(IGeneticService geneticService)
        {
            _geneticService = geneticService;
        }
        public IActionResult Index()
        {
            return View(new GetRouteDto());
        }
        public IActionResult GetRoute(GetRouteDto route)
        {
            var response = _geneticService.GetShortestPath(route);
            return View(response);
        }
	}
}
