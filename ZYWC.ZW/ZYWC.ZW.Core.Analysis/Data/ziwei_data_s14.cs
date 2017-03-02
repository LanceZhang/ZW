using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s14 : List<s14_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s14_xingdi
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public int index { get; set; }

        [XmlAttribute]
        public int type { get; set; }

        [XmlElement("title")]
        public string title { get; set; }


        [XmlElement("title1")]
        public string title1 { get; set; }


        [XmlElement("title2")]
        public string title2 { get; set; }


        [XmlElement("content")]
        public string content { get; set; }


        [XmlElement("huajienan")]
        public string huajienan { get; set; }


        [XmlElement("huajienu")]
        public string huajienu { get; set; }
    }
}
