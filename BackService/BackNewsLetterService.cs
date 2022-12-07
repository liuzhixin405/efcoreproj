using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spider.DataLayer.Model.NewsLetter;
using Spider.DataBusiness;
using Spider.ServiceLayer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spider.BackService
{
    public class BackNewsLetterService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public BackNewsLetterService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _newsLetterBusiness = scope.ServiceProvider
                      .GetRequiredService<INewsLetterBusiness>();
                    var _newsLetterLayer = scope.ServiceProvider
                      .GetRequiredService<INewsLetterLayer>();

                    await History(_newsLetterLayer, _newsLetterBusiness,100);
                    var webMaxId = await _newsLetterLayer.GetMaxIdByWeb(); //获取网页最新的数据的id
                                                                           //root.top_id > root.bottom_id
                    var dbMaxId = await _newsLetterBusiness.GetRootMaxId(); //获取数据库最新数据的id


                    var listItems = new List<ListItem>();
                    var roots = new List<Root>();
                    try
                    {
                       await DoWork(roots,webMaxId, dbMaxId, _newsLetterLayer,_newsLetterBusiness);                        
                    }
                    finally
                    {
                        if (roots.Count > 0)
                        {
                            await _newsLetterBusiness.AddRoot(roots);
                        }
                        await Task.Delay(1000 * 60 * 5);
                        //await Task.Delay(5000); //测试
                    }
                }
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roots"></param>
        /// <param name="webMaxId">第几到第几条</param>
        /// <param name="dbMaxId">数据库最大条数id</param>
        /// <param name="newsLetterLayer"></param>
        /// <param name="newsLetterBusiness"></param>
        /// <returns></returns>
        private async Task DoWork(List<Root> roots,Tuple<int, int> webMaxId,int dbMaxId,INewsLetterLayer newsLetterLayer,INewsLetterBusiness newsLetterBusiness)
        {
           
            if (dbMaxId >= webMaxId.Item1) //没有最新数据
                return;
            if (dbMaxId < webMaxId.Item1 && dbMaxId >= webMaxId.Item2)
            {
                var root = (await newsLetterLayer.GetById(dbMaxId + 1, dbMaxId + 1 - webMaxId.Item2));
                roots.Add(root);
                //取值webmax.Item1(包含)-dbMaxId(包含)之间的数据
            }
            else if (dbMaxId < webMaxId.Item2)
            {
                //取值webmax.Item1 -item2之间所有数据
                var root = await newsLetterLayer.GetById(webMaxId.Item1 + 1, webMaxId.Item1 + 1 - webMaxId.Item2);
                roots.Add(root);
            }
        }
    
        
        /// <summary>
        /// 历史数据
        /// </summary>
        /// <returns></returns>
        private async Task History(INewsLetterLayer newsLetterLayer, INewsLetterBusiness newsLetterBusiness,int limit=20)
        {
            
            var dbMinId =await newsLetterBusiness.GetRootMinId();
            var root =await newsLetterLayer.GetById(dbMinId, limit);
            if(root?.list?.Count>0)
            {
                await newsLetterBusiness.AddRoot(new List<Root> { root });
                await History(newsLetterLayer,newsLetterBusiness,limit);
            }
            return;
        }
    }
}
