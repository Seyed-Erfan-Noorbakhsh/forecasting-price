using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecasting_price
{
    public class CompareDto
    {
        public string Name { get; set; }
        public float RealPrice { get; set; }
        public float ForecastPrice { get; set; }
        public float PriceDifference { get; set; }
    }
}
