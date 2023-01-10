using Reptile.DataLayer.Model.NewsLetter;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Spider.DataBusiness.Dto
{
    public enum FilterBy
    {
        /// <summary>
        /// 不过滤
        /// </summary>
        [Display(Name = "All")] 
        NoFilter = 0,
        /// <summary>
        /// id
        /// </summary>
        [Display(Name = "By Id...")] 
        ById,
    }

    public static class LivesItemFilter
    {
        public static IQueryable<LivesItem> FilterBy(this IQueryable<LivesItem> query, FilterBy filterBy,string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue)) 
                return query;
            switch (filterBy)
            {
                case Dto.FilterBy.NoFilter:
                    return query;
                case Dto.FilterBy.ById:
                    var filterVote = int.Parse(filterValue);
                    return query.Where(x=>x.id== filterVote);
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }
    }
}
