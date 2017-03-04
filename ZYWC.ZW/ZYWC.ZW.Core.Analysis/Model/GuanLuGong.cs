using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class GuanLuGong : BasicGong
    {
        public override GongIndex Name
        {
            get { return GongIndex.官禄宫; }
        }

        public ShiYeFenXi ShiYeFenXi { get; set; } //2017-3-4 app中有多个，嫌多

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendLine(ShiYeFenXi.ToString());

            return sb.ToString();
        }
    }



    public class ShiYeFenXi
    {
        public int StarId { get; set; }

        public string Name { get; set; }

        public string juese { get; set; }

        public string zhiye { get; set; }

        public string zongping { get; set; }

        public string jianyi { get; set; }

        public string chenggongmijue { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            return string.Format(@"
{0}：
角色：{1}
职业：{2}
总评：{3}
建议：{4}
成功秘诀：{5}", Name, juese, zhiye, zongping, jianyi, chenggongmijue
       );
        }
    }
}