using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Models
{
    public class AlgoViewModel
    {
        public string SelectAlgo { get; set; }
        public List<SelectListItem> AlgosSelectList { get; set; }
    }
}
