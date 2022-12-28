using Algo.App.Data;
using Algo.App.Dtos;
using Algo.App.Models;
using Algo.App.Services.RouteDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.GeneticService
{
    public class GeneticService : IGeneticService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoutesDataService _routesDataService;
        public GeneticService(IHttpContextAccessor httpContextAccessor, IRoutesDataService routesDataService)
        {
            _httpContextAccessor = httpContextAccessor;
            _routesDataService = routesDataService;
        }
        public ServiceResponse GetShortestPath(GetRouteDto route)
        {
            ServiceResponse response = new ServiceResponse();
            List<Routes> routeList = _httpContextAccessor.HttpContext.Session.GetComplexData<List<Routes>>("RoutesTable");
            List<CityCode> cityList = _httpContextAccessor.HttpContext.Session.GetComplexData<List<CityCode>>("CityTable");
            double[,] graph = DataParsing.ListToMatrix(routeList,cityList.Count);
            GeneticAlgoResult result = GeneticAlgo.Genetic(graph);
            response.distance = result.distance;
            response.path = result.path;
            response.graph = DataParsing.GraphToString(graph);
            response.timeComplexity = "O(gnm) ,  g = no.of generations , n = population size, and m = size of individuals";
            response.spaceComplexity = "O(n)";
            _routesDataService.SaveData("Genetic Algorithm", route, response);
            return response;
        }
    }
}
