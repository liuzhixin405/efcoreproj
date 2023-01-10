using Microsoft.EntityFrameworkCore;
using Reptile.DataLayer.Model.CoinMarketCap;
using System;

namespace Reptile.DataLayer.Context
{
    public class CoinMarketCapContext: DbContext
    {
        public CoinMarketCapContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Root> Roots { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Owner>  Owners { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<ImagesItem> ImagesItems { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<CurrenciesItem> CurrenciesItems { get; set; }
        public DbSet<Avatar> Avatars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableDetailedErrors().EnableSensitiveDataLogging();
        }
    }
}
