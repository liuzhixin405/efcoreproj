using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reptile.DataLayer.Model.CoinMarketCap
{
    public class ListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gravityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Owner owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rootId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string textContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public List<string> photoIds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string commentCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string likeCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isLiked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string postTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string originalContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isYours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public List<string> topics { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public List<CurrenciesItem> currencies { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool bullish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool projectUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool linkCardVisible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string repostCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool pinned { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string languageCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ImagesItem> images { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool hasVote { get; set; }

        public int DataId { get; set; }
    }
}
