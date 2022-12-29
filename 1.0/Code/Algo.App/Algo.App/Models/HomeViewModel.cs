using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Models
{
    public class HomeViewModel
    {
        public string SelectCity { get; set; }
        public List<SelectListItem> CitiesSelectList { get; set; }
    }
}
