using Algo.App.Data;
using Algo.App.Dtos;
using Algo.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.DijkstraService
{
    public class DijkstraService : IDijkstraService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DijkstraService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public ServiceResponse GetShortestPath(GetRouteDto route)
        {
            ServiceResponse response = new ServiceResponse();
            List<Routes> routeList = _httpContextAccessor.HttpContext.Session.GetComplexData<List<Routes>>("RoutesTable");
            List<CityCode> cityList = _httpContextAccessor.HttpContext.Session.GetComplexData<List<CityCode>>("CityTable");
            double[,] graph = DataParsing.ListToMatrix(routeList,cityList.Count);
            int source = DataParsing.cityCodes[route.source];
            int destination = DataParsing.cityCodes[route.destination];
            DijkstraAlgoResult result = DijkstraAlgo.Dijkstra(graph, source - 1, destination - 1);
            response.distance = result.distances[destination - 1];
            response.path = PathGenerator.GeneratePath(result.parents, destination - 1);
            response.graph = graph;
            response.timeComplexity = "O(n^2)";
            response.spaceComplexity = "O(n)";
            return response;
        }
    }
}
