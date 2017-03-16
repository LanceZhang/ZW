using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class CaiBoGong : BasicGong
    {

        public CaiBoGong()
        {
            MingXing = new List<Xing>();
            TianZhaiXing = new List<Xing>();
        }


        public override GongIndex Name
        {
            get { return GongIndex.财帛宫; }
        }

        public string ShuangZhuXing { get; set; }
        public string ShuangZhuXingRisk { get; set; }

        public List<Xing> MingXing { get; set; }

        public List<Xing> TianZhaiXing { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            if (!string.IsNullOrEmpty(ShuangZhuXing))
            {
                sb.AppendFormat(@"
{0}+{1}
{2}", ZhuXing[0].Star.Name, ZhuXing[1].Star.Name, ShuangZhuXing);
            }


            sb.AppendFormat(@"
命宫对财运影响：
{0}
田宅宫对财运影响：
{1}", GetXingsString(MingXing), GetXingsString(TianZhaiXing));

            return sb.ToString();
        }
    }
}