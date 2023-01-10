using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reptile.DataLayer.Model.CoinMarketCap
{
    public class CurrenciesItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string symbol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string slug { get; set; }
        public int ListItemId { get; set; }
    }
}