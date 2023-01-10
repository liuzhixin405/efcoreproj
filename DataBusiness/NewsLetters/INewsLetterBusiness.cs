using Microsoft.EntityFrameworkCore;
using Reptile.DataLayer.Context;
using Reptile.DataLayer.Model.NewsLetter;
using Reptile.DataBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reptile.Utility.QueryObjects;
using Reptile.DbContextFactory;
using Orleans;
using Microsoft.AspNetCore.Components.Forms;

namespace Reptile.DataBusiness
{
    public interface INewsLetterBusiness
    {
        Task Add(List<ListItem> items);
        Task<int> GetRootMaxId();
        Task<int> GetRootMinId();
        Task AddRoot(List<Root> roots);
        IQueryable<LivesItem> SortFilterPage(SortFilterPageOptions options);
    }

    public class NewsLetterBusiness : INewsLetterBusiness
    {
        IReptileDbContextFactory _factory;
        public NewsLetterBusiness(IReptileDbContextFactory factory)
        {
            _factory = factory;
        }
        public async Task Add(List<ListItem> items)
        {
            using var context = _factory.CreateNewsLetterContext(DataLayer.Enum.WriteAndReadEnum.Write);
            await context.ListItems.AddRangeAsync(items);
            await context.SaveChangesAsync();
        }

        public async Task AddRoot(List<Root> roots)
        {
            if(roots.Count > 0)
            {
                using var context = _factory.CreateNewsLetterContext(DataLayer.Enum.WriteAndReadEnum.Write);
                await context.Roots.AddRangeAsync(roots);

                var result = await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetRootMaxId()
        {
            return await _factory.CreateNewsLetterContext(DataLayer.Enum.WriteAndReadEnum.Read).LivesItems.OrderByDescending(x => x.id).Select(x => x.id).FirstOrDefaultAsync();
        }

        public async Task<int> GetRootMinId()
        {
            return await _factory.CreateNewsLetterContext(DataLayer.Enum.WriteAndReadEnum.Read).LivesItems.OrderBy(x => x.id).Select(x => x.id).FirstOrDefaultAsync();
        }

        public IQueryable<LivesItem> SortFilterPage(SortFilterPageOptions options)
        {
            var query = _factory.CreateNewsLetterContext(DataLayer.Enum.WriteAndReadEnum.Read).LivesItems.AsNoTracking().OrderLivesItemBy(options.OrderByOptions).FilterBy(options.FilterBy, options.FilterValue);
            options.SetupRestOfDto(query);
            return query.Page(options.PageNum - 1, options.PageSize);
        }
    }
}
