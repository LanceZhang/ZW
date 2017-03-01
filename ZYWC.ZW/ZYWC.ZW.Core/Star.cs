﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYWC.ZW.Core
{
    public class Star
    {
        private static string liangStr = "陷不平利得旺庙"; //从陷开始++ -3 ~ 3,留一个4为空

        public string 星名 { get; set; }

        public int 类型 { get; set; }

        public int? 亮度 { get; set; }

        public string 化 { get; set; }

        public string 流化 { get; set; }

        public string 亮度Str
        {
            get
            {
                return 亮度.HasValue ? "(" + liangStr[亮度.Value + 3].ToString() + ")" : string.Empty;
            }
        }

        public string 化Str
        {
            get
            {
                return string.IsNullOrEmpty(化) ? string.Empty : "<" + 化 + ">";
            }
        }

        public string 流化Str
        {
            get
            {
                return string.IsNullOrEmpty(流化) ? string.Empty : "<流" + 化 + ">";
            }
        }

        public Star(string name)
        {
            星名 = name;
        }

    }
}
