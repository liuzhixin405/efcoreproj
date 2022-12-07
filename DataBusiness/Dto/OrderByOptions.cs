using Spider.DataLayer.Model.NewsLetter;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Spider.DataBusiness.Dto
{
    public enum OrderByOptions
    {
        /// <summary>
        /// id降序
        /// </summary>
        [Display(Name = "id ↓")]
        ByIdDesc,
        /// <summary>
        /// id升序
        /// </summary>
        [Display(Name = "id ↑")]
        ByIdAsc
    }

    public static class LivesItemSort
    {
        public static IQueryable<LivesItem> OrderLivesItemBy(this IQueryable<LivesItem> query, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.ByIdAsc:
                    return query.OrderBy(x => x.id);
                case OrderByOptions.ByIdDesc:
                    return query.OrderByDescending(x => x.id);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
