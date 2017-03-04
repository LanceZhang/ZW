using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s8 : List<s8_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s8_xingdi
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }


        [XmlElement("aiqingguan")]
        public string aiqingguan { get; set; }


        [XmlElement("jianyi")]
        public string jianyi { get; set; }


        [XmlElement("shihe")]
        public string shihe { get; set; }


        [XmlElement("miaowang")]
        public string miaowang { get; set; }


        [XmlElement("ruoxian")]
        public string ruoxian { get; set; }

    }
}
