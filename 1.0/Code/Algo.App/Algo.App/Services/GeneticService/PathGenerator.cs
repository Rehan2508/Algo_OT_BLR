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
            int last = parents.Length-1;
            for (int i = last ; i >= 0; i--)
            {
                if(i == last)
                {
                    path = DataParsing.cityNames.ElementAt(parents[i]).Value;
                }
                else{
                    path = DataParsing.cityNames.ElementAt(parents[i]).Value + " -> " + path + " ";
                }
                
            }
            return path;
        }
    }
}
