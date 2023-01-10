using Reptile.DataLayer.Model.NewsLetter;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Reptile.DataBusiness.Dto
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
        ByIdAsc,
        /// <summary>
        /// 时间降序
        /// </summary>
        [Description("时间降序")]
        ByDateDesc,
        /// <summary>
        /// 时间升序
        /// </summary>
        [Description("时间升序")]
        ByDateAsc
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
                case OrderByOptions.ByDateAsc:
                    return query.OrderBy(x => x.created_at);
                case OrderByOptions.ByDateDesc:
                    return query.OrderByDescending(x => x.created_at);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
