using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DataLayer.Model.NewsLetter
{
    public class LivesItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int livesItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 【京东方2022年前三季发展稳中见韧，投资布局元宇宙新赛道】金色财经报道，京东方发布2022年第三季度报告，前三季度公司实现营业收入1327.44亿元，实现归属于上市公司股东净利润52.91亿元。三季报发布当日，BOE（京东方）也同时对外发布了LTPO产线投建公告。公告表示，为进一步强化布局正在高速发展的“元宇宙”市场，BOE（京东方）拟投资290亿元在北京建设采用LTPO（低温多晶氧化物）技术的第6代新型半导体显示器件生产线项目，主要生产元宇宙核心器件的VR显示屏等。(金十)
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 京东方2022年前三季发展稳中见韧，投资布局元宇宙新赛道
        /// </summary>
        public string content_prefix { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int grade { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string highlight_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Image> images { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int created_at { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string created_at_zh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string attribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int up_counts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int down_counts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zan_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public List<string> readings { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int extra_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extra { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string prev { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string next { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public List<string> word_blocks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_show_comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_forbid_comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int comment_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string analyst_user { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string show_source_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vote_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vote { get; set; }
        public int listitemid { get; set; }
    }
}
