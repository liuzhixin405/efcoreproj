using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reptile.DataLayer.Model.NewsLetter
{
    public class Extra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Block_chain_index block_chain_index { get; set; }
    }

    public class Block_chain_index
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ExtraDetail> list { get; set; }
    }

    public class ExtraDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 上证指数
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? close { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? open { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? change { get; set; }
    }
}
