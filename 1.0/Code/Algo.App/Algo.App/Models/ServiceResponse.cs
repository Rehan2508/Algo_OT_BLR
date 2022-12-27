using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Models
{
    public class ServiceResponse
    {
        public string path { get; set; } = String.Empty;
        public double distance { get; set; }
        public string graph { get; set; }
        public string timeComplexity { get; set; }
        public string spaceComplexity { get; set; }
        public JsonResult jsonResult { get; set;}
    }
}
