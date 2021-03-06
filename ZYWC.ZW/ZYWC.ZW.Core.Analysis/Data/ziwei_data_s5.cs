﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s5 : List<s5_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s5_xingdi
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }


        [XmlArray("gong")]
        [XmlArrayItem("item")]
        public string[] items { get; set; }
    }
}
