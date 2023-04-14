using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecasting_price
{
    public class CryptoDto
    {
        [JsonProperty("name_en")]
        public string name_en { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }
        [JsonProperty("dominance")]
        public float dominance { get; set; }
        [JsonProperty("price")]
        public float price { get; set; }
        //other information//

    }
}
