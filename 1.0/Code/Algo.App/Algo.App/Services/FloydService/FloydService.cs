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
namespace Algo.App.Services.FloydService
{
    public class FloydService : IFloydService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoutesDataService _routesDataService;
        public FloydService(IHttpContextAccessor httpContextAccessor, IRoutesDataService routesDataService)
        {
            _httpContextAccessor = httpContextAccessor;
            _routesDataService = routesDataService;
        }
        public ServiceResponse GetShortestPath(GetRouteDto route)
        {
            ServiceResponse response = new ServiceResponse();
            List<Routes> routeList = _httpContextAccessor.HttpContext.Session.GetComplexData<List<Routes>>("RoutesTable");
            List<CityCode> cityList = _httpContextAccessor.HttpContext.Session.GetComplexData<List<CityCode>>("CityTable");
            double[,] graph = DataParsing.ListToMatrix(routeList, cityList.Count);
            int source = DataParsing.cityCodes[route.source];
            int destination = DataParsing.cityCodes[route.destination];
            FloydAlgoResult result = FloydAlgo.Floyd(graph, source - 1, destination - 1);
            double[,] floyd_Matrix = result.distances;
            response.distance = result.distances[source - 1, destination - 1];
            Console.WriteLine(response.distance);
            response.path = PathGenerator.GeneratePath(result.parents, destination - 1, source - 1);
            response.graph = DataParsing.GraphToString(floyd_Matrix);
            response.timeComplexity = "O(n^3)";
            response.spaceComplexity = "O(n)";
            _routesDataService.SaveData("Floyd Warshall Algorithm", route, response);
            return response;
        }
    }
}