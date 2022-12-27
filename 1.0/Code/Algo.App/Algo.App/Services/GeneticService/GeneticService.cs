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

namespace Algo.App.Services.GeneticService
{
    public class GeneticService : IGeneticService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GeneticService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
            response.graph = graph;
            response.timeComplexity = "O(n^2)";
            response.spaceComplexity = "O(n)";
            return response;
        }
    }
}
