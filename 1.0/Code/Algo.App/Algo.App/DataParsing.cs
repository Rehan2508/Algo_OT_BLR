using Algo.App.Dtos;
using Algo.App.Enums;
using Algo.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App
{
    public class DataParsing
    {
        public static IDictionary<string, int> cityCodes =
            new Dictionary<string, int>();
        public static IDictionary<int, string> cityNames =
            new Dictionary<int, string>();
        public static double[,] ListToMatrix(List<Routes> routes, int n)
        {
            double[,] graph = new double[n,n];
            foreach(Routes route in routes)
            {
                graph[route.sourceCode - 1,route.destinationCode - 1] = route.distance;
                graph[route.destinationCode - 1, route.sourceCode - 1] = route.distance;
            }
            return graph;
        }
        public static string GraphToString(double[,] graph)
        {
            string str = "{";
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                str += "[";
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    str += graph[i, j];
                    if (j != graph.GetLength(0) - 1)
                        str += ",";
                }
                str += "]";
                if (i != graph.GetLength(0) - 1)
                    str += ",";
            }
            str += "}";
            return str;
        }
        public static void setCityCodes(List<CityCode> cityCodeList)
        {
            foreach(CityCode cityCode in cityCodeList)
            {
                cityCodes.Add(cityCode.cityName, cityCode.code);
            }
        }
        public static void setCityName(List<CityCode> cityCodeList)
        {
            foreach (CityCode cityCode in cityCodeList)
            {
                cityNames.Add(cityCode.code, cityCode.cityName);
            }
        }
    }
}
