using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DataLayer.Model.NewsLetter
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? width { get; set; } = 0;
        public int? height { get; set; } = 0;
        public string url { get; set; }
        public string thumbnail { get; set; }

        public int livesitemid { get; set; }
    }
}
