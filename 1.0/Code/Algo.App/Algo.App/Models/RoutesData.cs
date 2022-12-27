using Algo.App.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Models
{
    [Table("SP_Route")]
    public class RoutesData
    {
        public int id { get; set; }
        public string algoName { get; set; }
        public GetRouteDto input { get; set; }
        public ServiceResponse output { get; set; }
    }
}
