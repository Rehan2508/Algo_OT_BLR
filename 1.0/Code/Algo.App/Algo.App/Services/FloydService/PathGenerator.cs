using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.FloydService
{
    public class PathGenerator
    {
        public static string GeneratePath(int[] parents, int destination)
        {
            string path = "" + DataParsing.cityNames[destination + 1];
            int i = destination;
            while (parents[i] >= 0)
            {
                path = DataParsing.cityNames[parents[i] + 1] + " -> " + path;
                i = parents[i];
            }
            return path;
        }
    }
}
