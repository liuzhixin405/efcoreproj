using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spider.DataLayer.Context;
using Spider.DataLayer.Enum;
using System;
using System.Linq;

namespace Spider.DbContextFactory
{
    public class NewsLetterContextFactory : INewsLetterContextFactory
    {
        private readonly  string _readConnectionString;
        private readonly string _writeConnectionString;
        

        public NewsLetterContextFactory(IConfiguration configuration)
        {
            _readConnectionString = configuration.GetConnectionString("WriteConnection");
            _writeConnectionString = configuration.GetConnectionString("ReadConnection");
            
        }

        public NewsLetterContext Create(WriteAndReadEnum writeAndRead)
        {
           
            DbContextOptionsBuilder dbContextOptionBuilder = new DbContextOptionsBuilder(new DbContextOptions<NewsLetterContext>());
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Read:
                    return new NewsLetterContext(dbContextOptionBuilder.UseSqlServer(_readConnectionString).Options);
                case WriteAndReadEnum.Write:
                    return new NewsLetterContext(dbContextOptionBuilder.UseSqlServer(_writeConnectionString).Options);
                default:
                    throw new ArgumentNullException($"{nameof(writeAndRead)}");
            } 
        }
       
    }
    public interface INewsLetterContextFactory
    {
        NewsLetterContext Create(WriteAndReadEnum writeAndRead);
    }
}
