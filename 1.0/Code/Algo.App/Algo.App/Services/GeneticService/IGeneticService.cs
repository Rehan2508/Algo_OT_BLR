using Algo.App.Dtos;
using Algo.App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.GeneticService
{
    public interface IGeneticService
    {
        public ServiceResponse GetShortestPath(GetRouteDto route);
    }
}
