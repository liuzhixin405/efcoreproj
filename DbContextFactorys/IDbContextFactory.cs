using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reptile.DataLayer.Context;
using Reptile.DataLayer.Enum;
using System;
using System.Linq;

namespace Reptile.DbContextFactory
{
    public class ReptileDbContextFactory : IReptileDbContextFactory
    {
       private readonly IConfiguration configuration;

        public ReptileDbContextFactory(IConfiguration configuration)
        {
            this.configuration= configuration;
        }

        public NewsLetterContext CreateNewsLetterContext(WriteAndReadEnum writeAndRead)
        {

            DbContextOptionsBuilder dbContextOptionBuilder = new DbContextOptionsBuilder(new DbContextOptions<NewsLetterContext>());
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Read:
                    return new NewsLetterContext(dbContextOptionBuilder.UseSqlServer(configuration["NewsLetterconnectionstrings:ReadConnection"]).Options);
                case WriteAndReadEnum.Write:
                    return new NewsLetterContext(dbContextOptionBuilder.UseSqlServer(configuration["NewsLetterconnectionstrings:WriteConnection"]).Options);
                default:
                    throw new ArgumentNullException($"{nameof(writeAndRead)}");
            }
        }

        public CoinMarketCapContext CreateCoinMarketCapContext(WriteAndReadEnum writeAndRead)
        {

            DbContextOptionsBuilder dbContextOptionBuilder = new DbContextOptionsBuilder(new DbContextOptions<CoinMarketCapContext>());
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Read:
                    return new CoinMarketCapContext(dbContextOptionBuilder.UseSqlServer(configuration["CoinMarketCapconnectionstrings:ReadConnection"]).Options);
                case WriteAndReadEnum.Write:
                    return new CoinMarketCapContext(dbContextOptionBuilder.UseSqlServer(configuration["CoinMarketCapconnectionstrings:WriteConnection"]).Options);
                default:
                    throw new ArgumentNullException($"{nameof(writeAndRead)}");
            }
        }
    }
    public interface IReptileDbContextFactory
    {
        NewsLetterContext CreateNewsLetterContext(WriteAndReadEnum writeAndRead);
        CoinMarketCapContext CreateCoinMarketCapContext(WriteAndReadEnum writeAndRead);
    }
}
