using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Models
{
    public class DijkstraAlgoResult
    {
        public double[] distances { get; set; }
        public int[] parents { get; set; }
    }
}
