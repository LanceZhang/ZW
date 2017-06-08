using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s61 : List<s61_xingdi>
    {
    }

    [XmlType("xingdi")]
    public class s61_xingdi
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement]
        public string minggong { get; set; }
        [XmlElement]
        public string fuqigong { get; set; }
        [XmlElement]
        public string shiyegong { get; set; }
    }
}
