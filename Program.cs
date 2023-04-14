using forecasting_price;

namespace CryptoAPI
{
    class Program
    {
        private static readonly string url = "https://api.wallex.ir/v1/currencies/stats";
        private static readonly string filePath = @"D:\\file.json";
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hi, Here we have some coins with their live information: ");
            Console.WriteLine("after you see the information, you can ask for forecasting with click [ ENTER ] .");
            Console.ResetColor();
            CryptoDto[] cryptos = await GetFromApi(url);
            InformationWorker informationWorker = new InformationWorker();
            await informationWorker.SaveToJson(filePath, cryptos);
            informationWorker.DisplayItems(cryptos);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*************************************************");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("if you want to start forecasting press ENTER");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*************************************************");
            Console.ResetColor();
            Console.WriteLine();

            Console.ReadLine(); //ta khandane data ha edame darad

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("our forecastings are at below : ");
            Console.WriteLine();
            Console.ResetColor();
           
               

            CryptoDto[] lastCryptos = await informationWorker.ReadFromJson(filePath);
            Forecasting forecasting = new Forecasting();
            CryptoDto[] forecastedCryptos = forecasting.Forecast(lastCryptos);

            CryptoDto[] newCryptoDtos = await GetFromApi(url);
            CompareDto[] compareDtos = forecasting.CompareDtos(newCryptoDtos, forecastedCryptos);

            informationWorker.DisplayItems(compareDtos);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You can also see the information file in your D drive on your system... \n thanks for using this program");
            Console.ResetColor();

        }
        private static async Task<CryptoDto[]> GetFromApi(string url)
        {
            RequestApi requestApi = new RequestApi();
            CryptoDto[] cryptos = await requestApi.GetItems(url);
            return cryptos;
        }
    }
}
