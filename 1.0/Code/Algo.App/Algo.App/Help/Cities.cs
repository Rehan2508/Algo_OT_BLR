using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algo.App.Models;

namespace Algo.App.Help
{
    public static class Cities
    {
        public static List<Routes> GetAll()
        {
            return new List<Routes>
            {
                new Routes(){id=1,source="Bangalore"},
                new Routes(){id=2,source="Delhi"},
                new Routes(){id=3,source="Ahmedabad"},
                new Routes(){id=4,source="Bhubaneshwar"},
                new Routes(){id=5,source="Chandigarh"},
                new Routes(){id=6,source="Chennai"},
                new Routes(){id=7,source="Cochin"},
                new Routes(){id=8,source="Hyderabad"},
                new Routes(){id=9,source="Indore"},
                new Routes(){id=10,source="Jaipur"},
                new Routes(){id=11,source="Kanpur"},
                new Routes(){id=12,source="Kolkata"},
                new Routes(){id=13,source="Lucknow"},
                new Routes(){id=14,source="Nagpur"},
                new Routes(){id=15,source="Nasik"},
                new Routes(){id=16,source="Panaji"},
                new Routes(){id=17,source="Patna"},
                new Routes(){id=18,source="Pondicherry"},
                new Routes(){id=19,source="Pune"},
                new Routes(){id=20,source="Ranchi"},
                new Routes(){id=21,source="Shillong"},
                new Routes(){id=22,source="Shimla"},
            };
        }
    }
}
