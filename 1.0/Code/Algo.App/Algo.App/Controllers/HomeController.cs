using Algo.App.Data;
using Algo.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
