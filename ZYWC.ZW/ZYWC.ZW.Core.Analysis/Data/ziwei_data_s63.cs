using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s63 : List<s63_gong>
    {
    }

    [XmlType("gong")]
    public class s63_gong
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement]
        public string jieshi { get; set; }
        [XmlElement]
        public string high { get; set; }
        [XmlElement]
        public string low { get; set; }
    }
}
