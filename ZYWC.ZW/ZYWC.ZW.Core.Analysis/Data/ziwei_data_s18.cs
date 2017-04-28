using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s18
    {
        [XmlArray("laoshi")]
        [XmlArrayItem("xingdi")]
        public List<s18_xingdi> laoshi { get; set; }
    }

    [XmlType("xingdi")]
    public class s18_xingdi
    {
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement("jianyi")]
        public string jianyi { get; set; }

    }
}
