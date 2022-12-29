using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.GeneticService
{
    public class PathGenerator
    {
        public static string GeneratePath(int[] parents)
        {
            string path = "";
            for (int i = 0; i < parents.Length; i++)
            {
                i = parents[i];
                path = DataParsing.cityNames[parents[i]] + " -> " + path + " ";
            }
            return path;
        }
    }
}
