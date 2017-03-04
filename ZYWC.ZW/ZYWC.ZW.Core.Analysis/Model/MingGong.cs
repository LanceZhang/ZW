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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendFormat(@"
身宫在：{0}
{1}", ShenGongPosition, ShenGongContent);

            return sb.ToString();
        }
    }
}