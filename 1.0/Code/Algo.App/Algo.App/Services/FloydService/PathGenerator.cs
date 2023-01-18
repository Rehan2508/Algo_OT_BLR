using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.FloydService
{
    public class PathGenerator
    {
        public static string GeneratePath(int[] parents, int destination, int source)
        {
            string path = DataParsing.cityNames[source + 1];
            for (int i = 1; i < parents.Length; i++)
            {
                path = path + "->" + DataParsing.cityNames[parents[i] + 1];
            }
            return path;
        }
    }
}
