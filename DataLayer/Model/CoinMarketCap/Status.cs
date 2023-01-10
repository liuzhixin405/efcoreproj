using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reptile.DataLayer.Model.CoinMarketCap
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error_message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string elapsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int credit_count { get; set; }
        public int rootId { get; set; }
    }
}
