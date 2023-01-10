using Reptile.DataLayer.Model.NewsLetter;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reptile.DataLayer.Model.CoinMarketCap
{
    public class Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string followingCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lastScore { get; set; }
        public int rootId { get; set; }
    }
}
