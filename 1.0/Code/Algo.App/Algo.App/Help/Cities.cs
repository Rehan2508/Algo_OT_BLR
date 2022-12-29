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
                new Routes(){id=1,source="Noida"},
                new Routes(){id=2,source="Bangalore"},
                new Routes(){id=3,source="Delhi"},
                new Routes(){id=4,source="Ahemdabad"},
                new Routes(){id=5,source="Bhubaneshwar"},
                new Routes(){id=6,source="Chandigarh"},
                new Routes(){id=7,source="Chennai"},
                new Routes(){id=8,source="Cochin"},
                new Routes(){id=9,source="Hyderabad"},
                new Routes(){id=10,source="Indore"},
                new Routes(){id=11,source="Jaipur"},
                new Routes(){id=12,source="Kanpur"},
                new Routes(){id=13,source="Kolkata"},
                new Routes(){id=14,source="Lucknow"},
                new Routes(){id=15,source="Nagpur"},
                new Routes(){id=16,source="Nasik"},
                new Routes(){id=17,source="Panaji"},
                new Routes(){id=18,source="Patna"},
                new Routes(){id=19,source="Pondicherry"},
                new Routes(){id=20,source="Pune"},
                new Routes(){id=21,source="Ranchi"},
                new Routes(){id=22,source="Shillong"},
                new Routes(){id=23,source="Shimla"},
            };
        }
    }
}
