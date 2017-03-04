using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class FuDeGong : BasicGong
    {
        public override GongIndex Name
        {
            get { return GongIndex.福德宫; }
        }

        public string ShuangZhuXing { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            if (!string.IsNullOrEmpty(ShuangZhuXing))
            {
            sb.AppendFormat(@"
{0}+{1}
{2}", ZhuXing[0].Star.Name, ZhuXing[1].Star.Name, ShuangZhuXing);
            }

            return sb.ToString();
        }
    }
}