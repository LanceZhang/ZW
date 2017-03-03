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

        public int Zhi { get; private set; }

        public string ZhiString
        {
            get
            {
                return zhiStr[Zhi - 1].ToString();
            }
        }

        public int Gan
        {
            get
            {
                return ganStr.IndexOf(GanString) + 1;
            }
        }

        public string GanString { get; set; }

        public string Name { get; set; }

        public string XianName { get; set; }

        public string LiuName { get; set; }

        public List<Star> Stars { get; set; }

        public bool Is_Ming { get; set; }

        public bool Is_Shen { get; set; }

        public int DaXian_From { get; set; }

        public int DaXian_To { get; set; }

        public List<int> XiaoXian { get; set; }


        public Gong Next;


        public Gong Previous;


        public Gong(int position)
        {
            Zhi = position;
            Stars = new List<Star>();
            XiaoXian = new List<int>();
        }


    }
}
