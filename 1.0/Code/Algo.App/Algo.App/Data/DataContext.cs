using Algo.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algo.App.Dtos;

namespace Algo.App.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<CityCode> CityCodes { get; set; }
    }
}
