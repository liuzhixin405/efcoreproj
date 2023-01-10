using Reptile.DataLayer.Model.NewsLetter;
using Reptile.DataBusiness;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Reptile.ServiceLayer
{
    public interface INewsLetterLayer
    {
        /// <summary>
        /// 获取网页的最新数据的id区间 item1=最新id ,item2=最新id-limit
        /// </summary>
        /// <returns></returns>
        Task<Tuple<int, int>> GetMaxIdByWeb(int limit = 20);
        Task<Root> GetById(int id=0, int limit = 20);
    }

    public class NewsLetterLayer: INewsLetterLayer
    {
        RestClient _restClient;
        public NewsLetterLayer()
        {
            _restClient =new RestClient();
        }

       
        public async Task<Tuple<int,int>> GetMaxIdByWeb(int limit=20)
        {
            var request = new RestRequest("https://api.jinse.com/noah/v2/lives")
                .AddQueryParameter("limit", limit)
                .AddQueryParameter("reading", "false")
            .AddQueryParameter("source", "web")
                .AddQueryParameter("flag", "up")
                .AddQueryParameter("id", 0)
                .AddQueryParameter("category", 0);
            request.Method = Method.Get;
            var result = await _restClient.ExecuteAsync<Root>(request);
           if(result.Data!= null)
            {
                return new Tuple<int, int>(result.Data.top_id, result.Data.bottom_id);
            }
            return null;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Root> GetById(int id=0, int limit = 20)
        {
            var request = new RestRequest("https://api.jinse.com/noah/v2/lives")
                .AddQueryParameter("limit", limit)
                .AddQueryParameter("reading", "false")
            .AddQueryParameter("source", "web")
                .AddQueryParameter("flag", "down")
                .AddQueryParameter("id", id)
                .AddQueryParameter("category", 0);
            request.Method = Method.Get;
            var result = await _restClient.ExecuteAsync<Root>(request);
            return result.Data;
        }
    }
}
