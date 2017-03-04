using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class MingGong : BasicGong
    {
        public override GongIndex Name
        {
            get { return GongIndex.命宫; }
        }

        public string ShenGongPosition { get; set; }

        public string ShenGongContent { get; set; }

        public string Youdian { get; set; }

        public string Quedian { get; set; }

        public string Fenxi { get; set; }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendFormat(@"
身宫在：{0}
{1}", ShenGongPosition, ShenGongContent);

            sb.AppendFormat(@"

优点：{0}
缺点：{1}
分析：{2}", Youdian, Quedian,Fenxi);

            return sb.ToString();
        }
    }
}