using Reptile.DataLayer.Model.CoinMarketCap;
using RestSharp;
using System.Threading.Tasks;

namespace Reptile.ServiceLayer.CoinMarketCaps
{
    public interface ICoinMarketCapLayer
    {
        ValueTask<Root> GetCapRoot();
    }

    public class CoinMarketCapLayer : ICoinMarketCapLayer
    {
        static string lastScore = string.Empty;
        public async ValueTask<Root> GetCapRoot()
        {
            var client = new RestSharp.RestClient();
            var request = new RestRequest("https://api-gravity.coinmarketcap.com/gravity/v3/gravity/time-line");
            request.AddJsonBody(new
            {
                control = "newest",
                experiment = "EX-1891-A",
                languageCode = "en",
                type = "Recommended"
            });
            request.Method = Method.Post;
            var result = await client.ExecuteAsync<Root>(request);

            var capRoot = result.Data;
            if(!(capRoot !=null && (capRoot.data.lastScore != lastScore)))
            {
                return new();
            }
            lastScore = result.Data.data.lastScore;
            return capRoot;
        }
    }
}
