using Algo.App.Data;
using Algo.App.Dtos;
using Algo.App.Help;
using Algo.App.Models;
using Algo.App.Services.DijkstraService;
using Algo.App.Services.FloydService;
using Algo.App.Services.GeneticService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algo.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDijkstraService _dijkstraService;
        private readonly IFloydService _floydService;
        private readonly IGeneticService _geneticService;


        public HomeController(ILogger<HomeController> logger, DataContext context, IHttpContextAccessor httpContextAccessor, IDijkstraService dijkstraService, IFloydService floydService, IGeneticService geneticService)
        {
            _logger = logger;
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

        public IActionResult Index()
        {
            var citiesData = Cities.GetAll();
            var algosData = Algorithms.GetAll();
            /*var algoModel = new AlgoModel();*/
            /*var model = new Routes();*/
            var mainModel = new UltimateModel();

            mainModel.routes = new Routes();
            mainModel.algoss = new AlgoModel();

            mainModel.routes.CitiesSelectList = new List<SelectListItem>();
            mainModel.algoss.AlgosSelectList = new List<SelectListItem>();

            foreach (var algo in algosData)
            {
                mainModel.algoss.AlgosSelectList.Add(new SelectListItem { Text = algo.algoName, Value = algo.algoName });
            }

            foreach (var city in citiesData)
            {
                mainModel.routes.CitiesSelectList.Add(new SelectListItem { Text = city.source, Value = city.source });
            }

            return View(mainModel);
        }

        [HttpPost]
        public IActionResult Index(UltimateModel model)
        {
            var selectedcitysource = model.routes.SelectedCitySource;
            var selectedcitydest = model.routes.SelectedCityDest;
            var selectAlgo = model.algoss.SelectedAlgoDropDown;
            System.Console.WriteLine(selectedcitysource + " " + selectedcitydest);
            System.Console.WriteLine(selectAlgo);
            ServiceResponse response = null;

            if (selectAlgo.Contains("Dijkstra's"))
            {
                DijkstraController dc = new DijkstraController(_dijkstraService);
                GetRouteDto route = new GetRouteDto
                {
                    source = selectedcitysource,
                    destination = selectedcitydest
                };
                response = _dijkstraService.GetShortestPath(route);
                ViewBag.path = response.path;
                ViewBag.distance = response.distance;
            }
            else if (selectAlgo.Contains("Floyd–Warshall"))
            {
                FloydController floyd = new FloydController(_floydService);
                GetRouteDto route = new GetRouteDto
                {
                    source = selectedcitysource,
                    destination = selectedcitydest
                };
                response = _floydService.GetShortestPath(route);
                ViewBag.path = response.path;
                ViewBag.distance = response.distance;
            }
            else if (selectAlgo.Contains("Genetic"))
            {
                GeneticController genetic = new GeneticController(_geneticService);
                GetRouteDto route = new GetRouteDto
                {
                    source = selectedcitysource,
                    destination = selectedcitydest
                };
                response = _geneticService.GetShortestPath(route);
                ViewBag.path = response.path;
                ViewBag.distance = response.distance;
            }
            System.Console.WriteLine(response);
            System.Console.WriteLine(response.path);
            //return RedirectToAction(nameof(Index));
            //return View(response);
            return View("_Output");
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