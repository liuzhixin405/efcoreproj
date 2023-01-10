using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Reptile.DataLayer.Model.CoinMarketCap
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string handle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatarId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createdTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string biography { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string originalBiography { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string websiteLink { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int authType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CoinListItem> coinList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int announceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Avatar avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string guid { get; set; }
        public int ListItemId { get; set; }
    }
}