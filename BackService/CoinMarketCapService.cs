using Microsoft.Extensions.Hosting;
using Reptile.DataBusiness;
using Reptile.ServiceLayer.CoinMarketCaps;
using System.Threading;
using System.Threading.Tasks;

namespace Reptile.BackService
{
    public class CoinMarketCapService : BackgroundService
    {
        private readonly ICoinMarketCapLayer _coinMarketCapLayer;
        private readonly ICoinMarketCapBusiness _coinMarketCapBusiness;
        public CoinMarketCapService(ICoinMarketCapLayer coinMarketCapLayer, ICoinMarketCapBusiness coinMarketCapBusiness)
        {
            _coinMarketCapLayer = coinMarketCapLayer;
            _coinMarketCapBusiness = coinMarketCapBusiness;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                var roots = await _coinMarketCapLayer.GetCapRoot();
                if (roots.data != null)
                {
                    await _coinMarketCapBusiness.AddRoot(roots);
                }
                await Task.Delay(5000);
            }
        
        }
    }
}
