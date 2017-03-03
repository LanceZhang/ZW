using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public abstract class BasicGong
    {
        public string GongWei { get; set; }

        public Gong SelfGong { get; set; }

        public Gong ZhaoGong { get; set; }

        public List<Gong> HuiGongs { get; set; }

        public List<Xing> ZhuXing { get; set; }

        public List<Xing> GoodXing { get; set; }

        public List<Xing> BadXing { get; set; }

        public int JiXiongZhiShu { get; set; }

    }


    public class Xing
    {
        public string Star { get; set; }

        public string Content { get; set; }
    }

}
