using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYWC.ZW.Core
{
    public class Gong
    {
        private static string ganStr = "甲乙丙丁戊己庚辛壬癸";
        private static string zhiStr = "子丑寅卯辰巳午未申酉戌亥";

        public int 支 { get; private set; }

        public string 支Str
        {
            get
            {
                return zhiStr[支 - 1].ToString();
            }
        }

        public int 干
        {
            get
            {
                return ganStr.IndexOf(干Str) + 1;
            }
        }

        public string 干Str { get; set; }

        public string 宫名 { get; set; }

        public string 大限宫名 { get; set; }

        public string 流年宫名 { get; set; }

        public List<Star> 天星 { get; set; }

        public bool is_命 { get; set; }

        public bool is_身 { get; set; }

        public int 大限From { get; set; }

        public int 大限To { get; set; }

        public List<int> 小限 { get; set; }


        public Gong Next;

        public Gong Previous;


        public Gong(int position)
        {
            支 = position;
            天星 = new List<Star>();
            小限 = new List<int>();
        }


    }
}
