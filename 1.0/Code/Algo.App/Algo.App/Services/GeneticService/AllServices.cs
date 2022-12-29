using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algo.App.Services.GeneticService
{
    class AllServices
    {
        public double[,] map;
        public List<int> cities;
        

        public List<List<int>> generatePopulation()
        {
            List<List<int>> population = new List<List<int>>();
            for (int i = 0; i < 100000; i++)
            {
                population.Add(new List<int>(createRoute(this.cities)));
            }
            return population;
        }

        public List<int> createRoute(List<int> cities)
        {
            Random rand = new Random();
            int limit = cities.Count;
            for(int i = 0; i < 50; i++)
            {
                int shuffleFrom = rand.Next(0, limit);
                int shuffleTo = rand.Next(0, limit);

                shuffleList(cities, shuffleFrom, shuffleTo);
            }
            return cities;
        }

        public void shuffleList(List<int> cities,int shuffleFrom,int shuffleTo)
        {
            int temp = cities[shuffleTo];
            cities[shuffleTo] = cities[shuffleFrom];
            cities[shuffleFrom] = temp;
        }

        public double calculateDistanceGraph(int self,int dest)
        {
            return map[self, dest];
        }
        public double calculateDistance(List<int> route)
        {
            double total = 0d;
            for(int i = 0; i < route.Count-1; i++)
            {
                int self = route[i];
                int dest = route[i + 1];
                double distance = calculateDistanceGraph(self,dest);
                total += distance;
            }
            return total; 
        }

        public double getFitness(List<int> route)
        {
            double totalDistance = calculateDistance(route);
            double fitness = 1d / totalDistance;
            return fitness;
        }

        public SortedList rankRoutes(List<List<int>> population)
        {
            SortedList ranked = new SortedList();
            for(int i = 0; i < population.Count; i++)
            {
                double key = getFitness(population[i]);
                List<int> value = population[i];
                if (!ranked.ContainsKey(key))
                {
                    ranked.Add(key, value);
                }
            }
            return ranked;
        }

        public List<List<int>> generateNewPopulation(SortedList sortList,int elitism)
        {
            double totalFitness = 0d;
            List<List<int>> population = new List<List<int>>();
            List<List<int>> newPopulation = new List<List<int>>();
            List<double> fitness = new List<double>();
            Random rand = new Random();

            foreach (DictionaryEntry pair in sortList)
            {
                double fit = Convert.ToDouble(pair.Key);
                fitness.Add(fit);
                population.Add(new List<int>((IEnumerable<int>)pair.Value));
                totalFitness += fit;
            }

            int eliteSt = population.Count - 1;
            int eliteEnd = population.Count - elitism;
            for(int i = eliteSt; i > eliteEnd; i--)
            {
                newPopulation.Add(population[i]);
            }

            for(int j = 0; j < population.Count-elitism; j++)
            {
                double d = totalFitness;
                double randomNumber = rand.NextDouble()*d;

                double runningSum = 0d;
                int index = 0;
                int lastAddedIndex = 0;
                while (runningSum < randomNumber)
                {
                    runningSum += fitness[index];
                    lastAddedIndex = index;
                    index++;
                }
                newPopulation.Add(population[lastAddedIndex]);
            }
            return newPopulation;
        }

        public List<List<int>> crossingParent(List<List<int>> parents, int elitism)
        {
            List<List<int>> newGeneration = new List<List<int>>();
            for(int e = 0; e < elitism; e++)
            {
                newGeneration.Add(parents[e]);
            }
            Random rand = new Random();
            bool flag = false;
            for(int i = 0; i < parents.Count; i+=2)
            {
                if(i+1 >= parents.Count)
                {
                    flag = true;
                    break;
                }
                List<int> parent1 = parents[i];
                List<int> parent2 = parents[i + 1];

                List<int> child = new List<int>();
                List<int> cross1 = new List<int>();
                List<int> cross2 = new List<int>();

                int geneA = rand.Next(parent1.Count);
                int geneB = rand.Next(parent2.Count);

                int start = Math.Min(geneA, geneB);
                int end = Math.Max(geneA, geneB);

                for(int j = geneA; j <= geneB; j++)
                {
                    cross1.Add(parent1[j]);
                }

                for(int k = 0; k < parent2.Count; k++)
                {
                    if (!cross1.Contains(parent2[k]))
                    {
                        cross2.Add(parent2[k]);
                    }
                }
                int add1 = 0;
                int add2 = 0;
                for(int l = 0; l < parent1.Count; l++)
                {
                    if(l >= geneA && l <= geneB)
                    {
                        child.Add(cross1[add1++]);
                    }
                    else
                    {
                        child.Add(cross2[add2++]);
                    }
                }
                newGeneration.Add(new List<int>(child));
            }
            if(flag)
            {
                newGeneration.Add(parents[parents.Count - 1]);
            }
            return newGeneration;
        }

        double mutaionRate = 0.7d;
        public List<List<int>> mutate(List<List<int>> childrens,int elitism)
        {
            List<List<int>> mutatedGeneration = new List<List<int>>();
            for(int i = 0; i < elitism; i++)
            {
                mutatedGeneration.Add(new List<int>(childrens[i]));
            }
            Random rand = new Random();

            for(int i = 0; i < childrens.Count; i++)
            {
                List<int> child = childrens[i];
                for(int j = 0; j < child.Count; j++)
                {
                    int swapTo = j;
                    int swapWith = 1;
                    double randomNumber = rand.NextDouble();
                    if (randomNumber < this.mutaionRate)
                    {
                        swapWith = (int)(randomNumber * child.Count);
                    }
                    int geneA = child[swapTo];
                    int geneB = child[swapWith];

                    child[swapWith] = geneA;
                    child[swapTo] = geneB;
                }
                mutatedGeneration.Add(new List<int>(child));
            }
            return mutatedGeneration;
        }
        public int[] pathToArray(List<int> list)
        {
            int[] arr = new int[list.Count];
            for(int i = 0; i < list.Count; i++)
            {
                arr[i] = list[i];
            }
            return arr;
        }

        public SortedList generateFinalList(SortedList firstGen,SortedList secGen, SortedList thirdGen, SortedList fourthGen)
        {
            SortedList finalList = new SortedList();

            foreach(DictionaryEntry pair in firstGen)
            {
                finalList.Add(pair.Key,pair.Value);
            }
            foreach (DictionaryEntry pair in secGen)
            {
                if (!finalList.ContainsKey(pair.Key))
                {
                    finalList.Add(pair.Key, pair.Value);
                }
            }
            foreach (DictionaryEntry pair in thirdGen)
            {
                if (!finalList.ContainsKey(pair.Key))
                {
                    finalList.Add(pair.Key, pair.Value);
                }
            }
            foreach (DictionaryEntry pair in fourthGen)
            {
                if (!finalList.ContainsKey(pair.Key))
                {
                    finalList.Add(pair.Key, pair.Value);
                }
            }
            return finalList;
        }

        public List<int> shortestPath(SortedList list)
        {
            List<int> path = (List<int>)list.GetByIndex(list.Count - 1);
            return path;
        }

    }
}
