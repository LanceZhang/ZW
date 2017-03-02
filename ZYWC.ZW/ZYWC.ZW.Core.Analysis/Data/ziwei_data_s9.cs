using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s9 : List<s9_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s9_xingdi
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }


        [XmlElement("juese")]
        public string juese { get; set; }

        [XmlElement("zhiye")]
        public string zhiye { get; set; }

        [XmlElement("zongping")]
        public string zongping { get; set; }


        [XmlElement("jianyi")]
        public string jianyi { get; set; }


        [XmlElement("ziwu")]
        public string ziwu { get; set; }


        [XmlElement("chouwei")]
        public string chouwei { get; set; }


        [XmlElement("yinshen")]
        public string yinshen { get; set; }


        [XmlElement("maoyou")]
        public string maoyou { get; set; }


        [XmlElement("chenxu")]
        public string chenxu { get; set; }


        [XmlElement("sihai")]
        public string sihai { get; set; }
    }
}
