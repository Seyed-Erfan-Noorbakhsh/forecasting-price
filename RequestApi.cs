
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecasting_price
{
    public class RequestApi
    {
        private readonly HttpClient _client;
        public RequestApi() 
        {
            _client = new HttpClient();
        }
        public async Task<CryptoDto[]> GetItems(string url)
        {
            var response = await _client.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDto>(jsonString);
            CryptoDto[] result = data.Result;
            return result;
        }
    }
}
