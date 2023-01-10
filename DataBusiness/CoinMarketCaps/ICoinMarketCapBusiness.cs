using Microsoft.EntityFrameworkCore;
using Reptile.DataLayer.Model.CoinMarketCap;
using Reptile.DataLayer.Model.NewsLetter;
using Reptile.DbContextFactory;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Reptile.DataBusiness
{
    public interface ICoinMarketCapBusiness
    {
        Task AddRoot(DataLayer.Model.CoinMarketCap.Root root);
    }

    public class CoinMarketCapBusiness : ICoinMarketCapBusiness
    {
        private readonly IReptileDbContextFactory _factory;
        public CoinMarketCapBusiness(IReptileDbContextFactory factory)
        {
            _factory= factory;
        }
        public async Task AddRoot(DataLayer.Model.CoinMarketCap.Root root)
        {
            if (root!=null)
            {
                using var context = _factory.CreateCoinMarketCapContext(DataLayer.Enum.WriteAndReadEnum.Write);
                if(root.data!=null|| root.status!=null)
                await context.Roots.AddAsync(root);
                foreach (var item in root.data.list)
                {
                    if(item.currencies!=null && item.currencies.Count > 0)
                    {
                        foreach (var currency in item.currencies)
                        {
                            if(!context.CurrenciesItems.Any(x=>x.id==currency.id))
                            await context.CurrenciesItems.AddAsync(currency);
                        }
                    }
                }
                var result = await context.SaveChangesAsync();
            }
        }
    }
}
