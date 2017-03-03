using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYWC.ZW.Core
{
    public class Star
    {
        private static string liangStr = "陷不平利得旺庙"; //从陷开始++ -3 ~ 3,留一个4为空

        public string Name { get; set; }

        public StarType Type { get; set; }

        public int? LiangDu { get; set; }

        public string Hua { get; set; }

        public string LiuHua { get; set; }

        public string LiangDuString
        {
            get
            {
                return LiangDu.HasValue ? "(" + liangStr[LiangDu.Value + 3].ToString() + ")" : string.Empty;
            }
        }

        public string HuaString
        {
            get
            {
                return string.IsNullOrEmpty(Hua) ? string.Empty : "<" + Hua + ">";
            }
        }

        public string LiuHuaString
        {
            get
            {
                return string.IsNullOrEmpty(LiuHua) ? string.Empty : "<流" + Hua + ">";
            }
        }

        public Star(string name, StarType type)
        {
            Name = name;
            Type = type;
        }


        public enum StarType
        {
            主星 = 1,
            月系 = 2,
            年系 = 3,
            时系 = 4,
            年干系 = 5,
            火铃 = 6,
            其它 = 7,
            博士十二 = 8,
            长生十二 = 9,
            年前十二 = 10,
            岁前十二 = 11
        }
    }
}
