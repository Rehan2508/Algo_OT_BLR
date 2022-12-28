using Algo.App.Dtos;
using Algo.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.RouteDataService
{
    public interface IRoutesDataService
    {
        public string SaveData(string algoName, GetRouteDto getRouteDto, ServiceResponse serviceResponse);
    }
}
