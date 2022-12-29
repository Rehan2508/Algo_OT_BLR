using Algo.App.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.GeneticService
{
	public class GeneticAlgo
	{
		public static int vertices;
		


		private static List<int> addCities()
        {
			List<int> cities = new List<int>();
			for(int i = 0; i < vertices; i++)
            {
				cities.Add(i);
            }
			return cities;
        } 
		public static Models.GeneticAlgoResult Genetic(double[,] graph)
        {
			vertices = graph.GetLength(0);
			AllServices service = new AllServices();
			service.cities = addCities();
			service.map = graph;
			
			List<List<int>> population = service.generatePopulation();
			SortedList firstGen = service.rankRoutes(population);
			int elitism = firstGen.Count / 10;
			List<List<int>> newPopulation = service.generateNewPopulation(firstGen,elitism);
			SortedList secGen = service.rankRoutes(newPopulation);
			elitism = secGen.Count / 10;
			List<List<int>> newGeneration = service.crossingParent(newPopulation,elitism);
			SortedList thirdGen = service.rankRoutes(newGeneration);
			elitism = thirdGen.Count / 10;
			List<List<int>> nextGeneration = service.mutate(newGeneration,elitism);
            SortedList fourthGen = service.rankRoutes(nextGeneration);
			SortedList optimization = service.generateFinalList(firstGen, secGen, thirdGen, fourthGen);
			List<int> shortestPath = service.shortestPath(optimization);
			double calcDistance = service.calculateDistance(shortestPath);
			 int[] path = service.pathToArray(shortestPath);
            Models.GeneticAlgoResult result = new Models.GeneticAlgoResult();
			result.distance = calcDistance;
			result.path = path;
			return result;
        }
	}
}
