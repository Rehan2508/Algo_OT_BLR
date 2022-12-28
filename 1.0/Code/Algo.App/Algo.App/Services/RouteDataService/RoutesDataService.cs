using Algo.App.Data;
using Algo.App.Dtos;
using Algo.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.RouteDataService
{
    public class RoutesDataService : IRoutesDataService
    {
        private readonly DataContext _context;
        public RoutesDataService(DataContext context)
        {
            _context = context;
        }
        public string SaveData(string algoName, GetRouteDto getRouteDto, ServiceResponse serviceResponse)
        {
            RoutesData routesData = new RoutesData();
            routesData.algoName = algoName;
            routesData.algoInput = JsonConvert.SerializeObject(getRouteDto);
            routesData.algoOutput = JsonConvert.SerializeObject(serviceResponse);
            _context.RoutesDatas.Add(routesData);
            _context.SaveChanges();
            return "Data added successfully";
        }
    }
}
