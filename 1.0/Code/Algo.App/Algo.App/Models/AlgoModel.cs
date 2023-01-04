using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Models
{
    public class AlgoModel
    { 
        public int algoId { get; set; }
        public string algoName { get; set; }

        [NotMapped]
        public string SelectedAlgoDropDown { get; set; }
        public List<SelectListItem> AlgosSelectList { get; set; }
    }
}
