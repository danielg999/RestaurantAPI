using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class TemperatureRequest
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public TemperatureRequest(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
