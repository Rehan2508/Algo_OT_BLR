using Algo.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Help
{
    public static class Algorithms
    {
        public static List<AlgoModel> GetAll()
        {
            return new List<AlgoModel>
            {
                new AlgoModel(){algoId=1,algoName="Dijkstra's Shortest Path First algorithm"},
                new AlgoModel(){algoId=2,algoName="Floyd–Warshall algorithm"},
                new AlgoModel(){algoId=3,algoName="Genetic Algorithms and heuristics"},
                new AlgoModel(){algoId=4,algoName="Traveling Salesman"},
            };
        }
    }
}
