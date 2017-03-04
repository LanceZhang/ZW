using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class FuQiGong : BasicGong
    {
        public override GongIndex Name
        {
            get { return GongIndex.夫妻宫; }
        }

        public AiQingFenXi AiQingFenXi { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendLine(AiQingFenXi.ToString());

            return sb.ToString();
        }
    }


    public class AiQingFenXi
    {
        public int StarId { get; set; }

        public string Name { get; set; }

        public string aiqingguan { get; set; }

        public string jianyi { get; set; }

        public string shihe { get; set; }

        public string liangdu { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            return string.Format(@"
{0}：
爱情观：{1}
大师建议：{2}
适合对象：{3}
主星对爱情的影响：{4}", Name, aiqingguan, jianyi, shihe, liangdu
       );
        }
    }
}