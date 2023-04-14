using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecasting_price
{
    public class InformationWorker
    {
        public async Task SaveToJson(string filePath , CryptoDto[] cryptos)
        {
            string jsonString = JsonConvert.SerializeObject(cryptos);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                await sw.WriteLineAsync(jsonString);
            }
        }
        public async Task<CryptoDto[]> ReadFromJson(string filePath)
        {
            string jsonString;
            using (StreamReader sr = new StreamReader(filePath))
            {
                jsonString = await sr.ReadToEndAsync();
            }
            CryptoDto[] cryptoDtos = JsonConvert.DeserializeObject<CryptoDto[]>(jsonString);
            return cryptoDtos;
        }
        public void DisplayItems(CryptoDto[] cryptos)
        {
            foreach (var crypto in cryptos)
            {
                Console.WriteLine($"name:{crypto.name_en} | rank: {crypto.rank} | dominance: {crypto.dominance} | price: {crypto.price}");
            }
        }

        public void DisplayItems(CompareDto[] compareCryptos)
        {
            foreach (var compareCrypto in compareCryptos)
            {
                Console.WriteLine($"name:{compareCrypto.Name} | Real Price: {compareCrypto.RealPrice} | Forecasted Price: {compareCrypto.ForecastPrice} | diffrence: {compareCrypto.PriceDifference}");
            }
        }
    }
}
