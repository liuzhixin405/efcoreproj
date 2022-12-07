using Microsoft.EntityFrameworkCore;
using Spider.DataLayer.Context;
using Spider.DataLayer.Model.NewsLetter;
using Spider.DataBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spider.Utility.QueryObjects;
using Spider.DbContextFactory;
using Orleans;
using Microsoft.AspNetCore.Components.Forms;

namespace Spider.DataBusiness
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
        INewsLetterContextFactory _factory;
        public NewsLetterBusiness(INewsLetterContextFactory factory)
        {
            _factory = factory;
        }
        public async Task Add(List<ListItem> items)
        {
            using var context = _factory.Create(DataLayer.Enum.WriteAndReadEnum.Write);
            await context.ListItems.AddRangeAsync(items);
            await context.SaveChangesAsync();
        }

        public async Task AddRoot(List<Root> roots)
        {
            using var context = _factory.Create(DataLayer.Enum.WriteAndReadEnum.Write);
            await context.Roots.AddRangeAsync(roots);
            
            var result = await context.SaveChangesAsync();
        }

        public async Task<int> GetRootMaxId()
        {
            return await _factory.Create(DataLayer.Enum.WriteAndReadEnum.Read).LivesItems.OrderByDescending(x => x.id).Select(x => x.id).FirstOrDefaultAsync();
        }

        public async Task<int> GetRootMinId()
        {
            return await _factory.Create(DataLayer.Enum.WriteAndReadEnum.Read).LivesItems.OrderBy(x => x.id).Select(x => x.id).FirstOrDefaultAsync();
        }

        public IQueryable<LivesItem> SortFilterPage(SortFilterPageOptions options)
        {
            var query = _factory.Create(DataLayer.Enum.WriteAndReadEnum.Read).LivesItems.AsNoTracking().OrderLivesItemBy(options.OrderByOptions).FilterBy(options.FilterBy, options.FilterValue);
            options.SetupRestOfDto(query);
            return query.Page(options.PageNum - 1, options.PageSize);
        }
    }
}
