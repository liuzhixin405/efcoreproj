using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spider.DataBusiness;
using System.Threading.Tasks;

namespace Spider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        private readonly INewsLetterBusiness _newsLetterBusiness;
        public NewsLetterController(INewsLetterBusiness newsLetterBusiness)
        {
            _newsLetterBusiness = newsLetterBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> GetLivesItemPage 
        (SortFilterPageOptions options)
        {
            var bookList = await _newsLetterBusiness       
                .SortFilterPage(options)
                .ToListAsync();
            return Ok(new LivesItemListCombinedDto(options, bookList));
        }
    }
}
