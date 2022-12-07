using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DataLayer.Model.NewsLetter
{
    public class Root
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int news { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int top_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bottom_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string default_share_img { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string prefix_link { get; set; }
    }
}
