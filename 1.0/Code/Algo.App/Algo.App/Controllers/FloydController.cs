using Algo.App.Data;
using Algo.App.Dtos;
using Algo.App.Services.FloydService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Controllers
{
    public class FloydController : Controller
    {
        private readonly IFloydService _floydService;

        public FloydController(IFloydService floydService)
        {
            _floydService = floydService;
        }
        public IActionResult Index()
        {
            return View(new GetRouteDto());
        }
        public IActionResult GetRoute(GetRouteDto route)
        {
            var response = _floydService.GetShortestPath(route);
            return View(response);
        }
    }
}
