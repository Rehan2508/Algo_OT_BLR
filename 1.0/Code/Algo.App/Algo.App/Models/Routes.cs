using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Algo.App.Models
{
    [Table("SP_Routes")]
    public class Routes
    {
        [Column("Id")]
        public int id { get; set; }
        [Column("city_from")]
        public string source { get; set; }
        [Column("from_city_code")]
        public int sourceCode { get; set; }
        [Column("city_to")]
        public string destination { get; set; }
        [Column("to_city_code")]
        public int destinationCode { get; set; }
        [Column("distance")]
        public int distance { get; set; }

        [NotMapped]
        public string SelectedCitySource { get; set; }
        [NotMapped]
        public string SelectedCityDest { get; set; }
        [NotMapped]
        public List<SelectListItem> CitiesSelectList { get; set; }
    }
}
