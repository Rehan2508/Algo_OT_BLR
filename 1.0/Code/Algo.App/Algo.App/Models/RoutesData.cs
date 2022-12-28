using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Models
{
    [Table("SP_ShortestPathHeader")]
    public class RoutesData
    {
        [Column("route_id")]
        public int id { get; set; }
        [Column("algoName")]
        public string algoName { get; set; }
        [Column("algoInput")]
        public string algoInput { get; set; }
        [Column("algoOutput")]
        public string algoOutput { get; set; }
    }
}
