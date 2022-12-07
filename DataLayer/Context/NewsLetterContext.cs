using Microsoft.EntityFrameworkCore;
using Spider.DataLayer.Model.NewsLetter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DataLayer.Context
{
    public class NewsLetterContext:DbContext
    {
        public NewsLetterContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        //private readonly string _connsctionString;

        public DbSet<Root> Roots { get; set; }
        public DbSet<LivesItem> LivesItems { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connsctionString);
            optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableDetailedErrors().EnableSensitiveDataLogging();
        }
    }
}
