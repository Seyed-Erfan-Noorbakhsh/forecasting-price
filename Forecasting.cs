using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecasting_price
{
    public class Forecasting
    {
        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
        public CryptoDto[] Forecast(CryptoDto[] lastData)
        {
            List<CryptoDto> result = new List<CryptoDto>();
            foreach (var data in lastData)
            {
                double randomNumber = GetRandomNumber(-0.07, 0.07);
                data.price += data.price*(float)randomNumber;
                result.Add(data);
            }
            return result.ToArray();
        }
        public CompareDto[] CompareDtos(CryptoDto[] realCryptoDto,CryptoDto[] forecastedDto)
        {
            List<CompareDto> compareDtos = new List<CompareDto>();
            for (int i = 0;i<realCryptoDto.Length;i++)
            {
                CompareDto compareDto = new CompareDto()
                {
                    Name = realCryptoDto[i].name_en,
                    RealPrice = realCryptoDto[i].price,
                    ForecastPrice = forecastedDto[i].price,
                    PriceDifference = forecastedDto[i].price - realCryptoDto[i].price
                };
                compareDtos.Add(compareDto);
            }
            return compareDtos.ToArray();
        }
    }
}
